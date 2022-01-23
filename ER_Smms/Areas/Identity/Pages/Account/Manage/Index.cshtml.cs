using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ER_Smms.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ER_Smms.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<IdentityAppUser> _userManager;
        private readonly SignInManager<IdentityAppUser> _signInManager;

        public IndexModel(
            UserManager<IdentityAppUser> userManager,
            SignInManager<IdentityAppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {

            [Display(Name = "First Name")] // Added /ER
            public string FirstName { get; set; }

            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            //[Display(Name = "BirthDate")]
            //public string BirthDate { get; set; }

            [Display(Name = "Phone Number")]
            public string PhoneNumber { get; set; }

            [Display(Name = "Address")]
            public string Address { get; set; }

            [Display(Name = "Postcode")]
            public int Postcode { get; set; }

            [Display(Name = "City")]
            public string City { get; set; }
        }

        private async Task LoadAsync(IdentityAppUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var firstName = user.FirstName; // Added /ER
            var lastName = user.LastName;
            //var birthDate = user.BirthDate;
            var address = user.Address;
            var postcode = user.Postcode;
            var city = user.City;



        Username = userName;

            Input = new InputModel // Added /ER
            {
                FirstName = firstName,
                LastName = lastName,
                //BirthDate = birthDate,
                PhoneNumber = phoneNumber,
                Address = address,
                Postcode = postcode,
                City = city
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var firstName = user.FirstName; // Added /ER
            if (Input.FirstName != firstName)
            {
                user.FirstName = Input.FirstName;
                await _userManager.UpdateAsync(user);
            }

            var lastName = user.LastName;
            if (Input.LastName != lastName)
            {
                user.LastName = Input.LastName;
                await _userManager.UpdateAsync(user);
            }

            //var birthDate = user.BirthDate;
            //if (Input.BirthDate != birthDate)
            //{
            //    user.BirthDate = Input.BirthDate;
            //    await _userManager.UpdateAsync(user);
            //}

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            var address = user.Address;
            if (Input.Address != address)
            {
                user.Address = Input.Address;
                await _userManager.UpdateAsync(user);
            }

            var postcode = user.Postcode;
            if (Input.Postcode != postcode)
            {
                user.Postcode = Input.Postcode;
                await _userManager.UpdateAsync(user);
            }

            var city = user.City;
            if (Input.City != city)
            {
                user.City = Input.City;
                await _userManager.UpdateAsync(user);
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
