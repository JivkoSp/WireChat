using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NETCore.MailKit.Core;
using Wire.Models;

namespace Wire.Pages.EmailVerificationPage
{
    public class EmailVerificationModel : PageModel
    {
        private UserManager<AppUser> UserManager;
        private IEmailService EmailService;
        [BindProperty]
        public string Email { get; set; }

        public EmailVerificationModel(UserManager<AppUser> userManager, IEmailService emailService)
        {
            UserManager = userManager;
            EmailService = emailService;
        }

        public void OnGet(string UserEmail)
        {
            Email = UserEmail;
        }

        public async Task OnPostAsync()
        {
            var user = await UserManager.FindByEmailAsync(Email);
            var confirmCode = await UserManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmLink = Url.PageLink("/EmailVerificationPage/EmailVerification", pageHandler: "ConfirmEmail",
              values: new { UserId = user.Id, Code = confirmCode }, protocol: "http", host: "localhost:64643");

            await EmailService.SendAsync(user.Email, "Email Verification", 
                $"<h2>Welcome to WireChat, {user.UserName}.</h2> " +
                $"<p>Please confirm your account by <a href='{HtmlEncoder.Default.Encode(confirmLink)}'>clicking here</a>.</p>", true);
        }

        public async Task<IActionResult> OnGetConfirmEmail(string UserId, string Code)
        {
            var User = await UserManager.FindByIdAsync(UserId);
            var result = await UserManager.ConfirmEmailAsync(User, Code);

            if (result.Succeeded)
            {
                return RedirectToPage("/SignInPage/SignIn");
            }

            return BadRequest();
        }
    }
}
