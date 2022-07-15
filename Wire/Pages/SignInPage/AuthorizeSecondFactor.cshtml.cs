using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Authenticator;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Wire.Models;
using Wire.Models.Dtos;

namespace Wire.Pages.SignInPage
{
    public class AuthorizeSecondFactorModel : PageModel
    {
        private SignInManager<AppUser> SignInManager;

        private static string TwoFactorKey(AppUser user)
        {
            return $"myverysecretkey+{user.Email}";
        }

        public bool RememberMe { get; set; }

        public AuthorizeSecondFactorModel(SignInManager<AppUser> signInManager)
        {
            SignInManager = signInManager;
        }

        public void OnGet(bool RememberMe)
        {
            this.RememberMe = RememberMe;
        }

        public async Task<IActionResult> OnPostAsync(ManageUserDto manageUserDto)
        {
            var userCookie = await SignInManager.GetTwoFactorAuthenticationUserAsync();

            TwoFactorAuthenticator twoFactor = new TwoFactorAuthenticator();
            bool isValid = twoFactor.ValidateTwoFactorPIN(TwoFactorKey(userCookie), manageUserDto.TwoFaCode);
            if (!isValid)
            {
                return RedirectToPage("/SignInPage/SignIn");
            }

            await SignInManager.SignInAsync(userCookie, manageUserDto.RememberMe);
            return RedirectToAction("HomePage", "Home");
        }
    }
}
