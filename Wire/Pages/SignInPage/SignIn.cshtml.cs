using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Wire.Models;

namespace Wire.Pages.SignInPage
{
    public class SignInModel : PageModel
    {
        private SignInManager<AppUser> SignInManager;

        [BindProperty]
        [Required(ErrorMessage = "Incorrect username or password.")]
        public string UserName { get; set; }

        [BindProperty]
        [Required (ErrorMessage = "Incorrect username or password.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [BindProperty]
        public bool RememberMe { get; set; }

        public SignInModel(SignInManager<AppUser> signInManager)
        {
            SignInManager = signInManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                var result = await SignInManager.PasswordSignInAsync(UserName, Password, RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("HomePage", "Home");
                }
                else if(result.RequiresTwoFactor)
                {                  
                    return RedirectToPage("/SignInPage/AuthorizeSecondFactor", new { RememberMe = RememberMe });
                }
            }

            
            return Page();
        }
    }
}
