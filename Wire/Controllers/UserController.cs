using Google.Authenticator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NETCore.MailKit.Core;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Wire.Data.Repository.UnitOfWork;
using Wire.Models;
using Wire.Models.Dtos;
using Wire.Models.ViewModels;

namespace Wire.Controllers
{
    public class UserController : Controller
    {
        private UserManager<AppUser> UserManager;
        private IEmailService EmailService;
        private IUnitOfWork UnitOfWork;

        private static string TwoFactorKey(AppUser user)
        {
            return $"myverysecretkey+{user.Email}";
        }

        public UserController(UserManager<AppUser> userManager, IEmailService emailService,
            IUnitOfWork unitOfWork)
        {
            UserManager = userManager;
            EmailService = emailService;
            UnitOfWork = unitOfWork;
        }

        public async Task<IActionResult> UserProfile()
        {
            var user = await UserManager.GetUserAsync(User);
            TwoFactorAuthenticator twoFactor = new TwoFactorAuthenticator();
            var setupInfo = twoFactor.GenerateSetupCode("Wire", user.Email, TwoFactorKey(user), false, 2);

            ViewBag.SetupCode = setupInfo.ManualEntryKey;
            ViewBag.BarcodeImageUrl = setupInfo.QrCodeSetupImageUrl;

            return View
                (
                    new UserProfileViewModel
                    {
                        AppUser = user,
                        ProfilePictures = UnitOfWork.ProfilePictureRepo.GetProfilePictures()
                    }
                );
        }

        [HttpPost]
        public async Task<JsonResult> UserProfile(ManageUserDto manageUserDto)
        {
            try
            {
                var user = await UserManager.GetUserAsync(User);

                if (manageUserDto.TwoFaAuth && manageUserDto.TwoFaType == "QRCode")
                {
                    TwoFactorAuthenticator twoFactor = new TwoFactorAuthenticator();
                    bool isValid = twoFactor.ValidateTwoFactorPIN(TwoFactorKey(user), manageUserDto.TwoFaCode);
                    if (!isValid)
                    {
                        return new JsonResult("Invalid auth code entered!");
                    }

                    await UserManager.SetTwoFactorEnabledAsync(user, true);

                    return new JsonResult("Changes are applied, two factor auth with qrcode added.");
                }

                if(manageUserDto.ChangePass)
                {
                    var confirmCode = await UserManager.GenerateEmailConfirmationTokenAsync(user);
                    var confirmLink = Url.ActionLink("UserPasswordChange", "/User",
                      values: new { UserId = user.Id, Code = confirmCode }, protocol: "http", host: "localhost:64643");

                    await EmailService.SendAsync(user.Email, "Reset Password", $"<h2>Hi, {user.UserName}.</h2>" +
                        $"<p>If this request was made by you, confirm it by " +
                        $"<a href='{HtmlEncoder.Default.Encode(confirmLink)}'>clicking here</a>.</p>", true);

                    return new JsonResult("Changes are applied, password change email is send.");
                }
            }
            catch
            {
                return new JsonResult("Changes are not applied, something went wrong!");
            }

            return new JsonResult("Changes are not applied");
        }

        [HttpPost]
        public async Task<JsonResult> DisableTwoFaAuth(ManageUserDto manageUserDto)
        {
            var user = await UserManager.GetUserAsync(User);

            TwoFactorAuthenticator twoFactor = new TwoFactorAuthenticator();
            bool isValid = twoFactor.ValidateTwoFactorPIN(TwoFactorKey(user), manageUserDto.TwoFaCode);
            if (!isValid)
            {
                return new JsonResult("Invalid auth code entered!");
            }

            await UserManager.SetTwoFactorEnabledAsync(user, false);

            return new JsonResult("Changes are applied.");
        }

        public async Task<IActionResult> UserPasswordChange(string UserId, string Code)
        {
            var User = await UserManager.FindByIdAsync(UserId);
            var result = await UserManager.ConfirmEmailAsync(User, Code);

            if(result.Succeeded)
            {
                return View(new PasswordChangeDto { UserId = User.Id });
            }

            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> UserPasswordChange(PasswordChangeDto passwordChangeDto)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var user = await UserManager.GetUserAsync(User);
                    var result = await UserManager.
                        ChangePasswordAsync(user, passwordChangeDto.OldPassword, passwordChangeDto.NewPassword);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("UserProfile");
                    }
                }
                catch
                {
                    return BadRequest();
                }                
            }

            return View(passwordChangeDto);
        }

        [HttpPost]
        public async Task<JsonResult> MessageProfile(MessageProfileDto messageProfileDto)
        {
            try
            {
                if(messageProfileDto.DontRemember)
                {
                    AnonymUser anonymUser = new AnonymUser
                    {
                        AppUserId = messageProfileDto.UserId
                    };

                    await UnitOfWork.AnonymUserRepo.AddAsync(anonymUser);
                }
                else
                {
                    var messageTimeToLive = UnitOfWork.MessageTimeToLiveRepo.FindMessage(messageProfileDto.UserId);

                    if(messageTimeToLive != null)
                    {
                        messageTimeToLive.LifeSpan = messageProfileDto.MessageTimeToLife;
                        UnitOfWork.MessageTimeToLiveRepo.Update(messageTimeToLive);
                    }
                    else
                    {
                        MessageTimeToLive message = new MessageTimeToLive
                        {
                            AppUserId = messageProfileDto.UserId,
                            LifeSpan = messageProfileDto.MessageTimeToLife
                        };

                        await UnitOfWork.MessageTimeToLiveRepo.AddAsync(message);
                    }
                }

                await UnitOfWork.SaveChangesAsync();
            }
            catch
            {
                return new JsonResult("Changes are not applied, something went wrong!");
            }

            return new JsonResult("Message changes are applied");
        }

        [HttpPost]
        public async Task<JsonResult> UserImgProfile(int imgId)
        {
            var user = await UserManager.GetUserAsync(User);
            user.ProfilePictureId = imgId;
            var result = await UserManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return new JsonResult("Profile changes are applied");
            }
            return new JsonResult("Changes are not applied, something went wrong!");
        }
    }
}
