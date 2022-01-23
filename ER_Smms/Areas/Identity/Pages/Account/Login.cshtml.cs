using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ER_Smms.Models;

namespace ER_Smms.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly UserManager<IdentityAppUser> _userManager;
        private readonly SignInManager<IdentityAppUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;

        public LoginModel(SignInManager<IdentityAppUser> signInManager,
            ILogger<LoginModel> logger,
            UserManager<IdentityAppUser> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl = returnUrl ?? Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    //var checkUserRole = await _userManager.IsInRoleAsync(user, "Admin")

                    //if (User.IsInRole("Admin"))/*  (User.IsInRole("Admin"))*/
                    //{

                    //    System.Diagnostics.Debug.WriteLine("Admin logged in");
                    //    return Redirect("~/Admin/Index");
                    //}
                    //else if (User.IsInRole("User"))
                    //{
                    //    System.Diagnostics.Debug.WriteLine("User logged in now");
                    //    return Redirect("~/User/Index");
                    //}
                    //else
                    //{
                    //System.Diagnostics.Debug.WriteLine(User.Identity);
                    //System.Diagnostics.Debug.WriteLine("the else in the if loops.......User logged in.");
                    //_logger.LogInformation("the else in the if loops.......User logged in.");
                    return RedirectToAction("Index", "Frontend");
                    //}
                    //return RedirectToAction("CheckWhatRoleAndRedirect");
                }


                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, Input.RememberMe });
                }

                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }

                else
                {
                    System.Diagnostics.Debug.WriteLine(result);
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        //public async Task<IActionResult> CheckWhatRoleAndRedirect()
        //{
        //    if (SignInManager.IsSignedIn(User) && User.IsInRole("Admin"))/*  (User.IsInRole("Admin"))*/
        //    {
        //        System.Diagnostics.Debug.WriteLine("Admin logged in");
        //        return Redirect("~/Admin/Index");
        //    }
        //    else if (User.IsInRole("User"))
        //    {
        //        System.Diagnostics.Debug.WriteLine("User logged in now");
        //        return Redirect("~/User/Index");
        //    }
        //    else
        //    {
        //        _logger.LogInformation("the else in the if loops.......User logged in.");
        //        return RedirectToAction("Index", "People");
        //    }
        //}

    }
}
