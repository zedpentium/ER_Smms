using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using ER_Smms.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;


namespace ER_Smms.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityAppUser> _signInManager;
        private readonly UserManager<IdentityAppUser> _userManager;
        //private readonly RoleManager<IdentityAppUser> _roleManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<IdentityAppUser> userManager,
            SignInManager<IdentityAppUser> signInManager,
            //RoleManager<IdentityAppUser> roleManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            //_roleManager = roleManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress(ErrorMessage = "{0} måste vara en epost-adress")]
            [Display(Name = "AnvändarNamn (epost):")]
            public string Email { get; set; }


            //Added FirstName, LastName and BirthDate /ER
            [Required]
            [StringLength(100, ErrorMessage = "{0} måste vara minst {2} och max {1} bokstäver långt.", MinimumLength = 1)]
            [DataType(DataType.Text)]
            [Display(Name = "Förnamn:")]
            public string FirstName { get; set; }

            [Required]
            [StringLength(30, ErrorMessage = "{0} måste vara minst {2} och max {1} bokstäver långt.", MinimumLength = 1)]
            [DataType(DataType.Text)]
            [Display(Name = "Efternamn:")]
            public string LastName { get; set; }

            //[Required]
            //[StringLength(30, ErrorMessage = "The {0} must be at Birthdate of at least 6 numbers.", MinimumLength = 6)]
            //[DataType(DataType.Date)]
            //[Display(Name = "BirthDate")]
            //public string BirthDate { get; set; }

            //[Required]
            //[StringLength(30, ErrorMessage = "The {0} must be at Birthdate of at least 6 numbers.", MinimumLength = 6)]
            //[DataType(DataType.Date)]
            //[Display(Name = "BirthDate")]
            //public string BirthDate { get; set; }


            [Required]
            [StringLength(100, ErrorMessage = "{0} måste vara minst {2} och max {1} tecken långt.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Lösenord:")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Bekräfta Lösenord:")]
            [Compare("Password", ErrorMessage = "Lösenordet och bekräftelse-lösenordet är inte lika.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new IdentityAppUser { UserName = Input.Email, Email = Input.Email, FirstName = Input.FirstName, LastName = Input.LastName  /*, BirthDate = Input.BirthDate*/ }; //Added FirstName,LastName and BirthDate /ER
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    //var um = new UserManager<IdentityAppUser>(
                    //new UserStore<IdentityAppUser>(AppDbContext));

                    var assignRoleresult = await _userManager.AddToRoleAsync(user, "User");
                    //if (!result.Succeeded)
                        //Errors(result);

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code, returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
