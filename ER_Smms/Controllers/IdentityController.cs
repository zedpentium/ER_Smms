using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ER_Smms.Models;
using ER_Smms.Models.ViewModels.Admin;
using ER_Smms.Models.ViewModels.Identity;
using ER_Smms.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace ER_Smms.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class IdentityController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<IdentityAppUser> _userManager;
        private SignInManager<IdentityAppUser> _signInManager;
        private readonly ILogger<CreateAccountApplicantViewModel> _logger;
        private readonly IEmailSender _emailSender;

        public IdentityController(
            RoleManager<IdentityRole> roleMgr, UserManager<IdentityAppUser> userMrg,
            SignInManager<IdentityAppUser> signInManager, ILogger<CreateAccountApplicantViewModel> logger,
            IEmailSender emailSender
            )
        {
            _roleManager = roleMgr;
            _userManager = userMrg;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }


        // ---- Lists -------
        public IActionResult ListAllRoles()
        {
            return View("RoleList", _roleManager.Roles);
        }



        public IActionResult ListAllUsers()
        {
            UserListViewModel userList = new UserListViewModel()
            { UserListView = _userManager.Users.ToList() };

            ToastMessageShow();

            return View("UserList", userList);
        }



        // ----- Errors -----------------------
        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }


        // --- START ---* Manage Roles ***********------
        public IActionResult Create() => View("CreateRole");


        [HttpPost]
        public async Task<IActionResult> Create([Required] string name)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            }
            return View(name);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            }
            else
                ModelState.AddModelError("", "No role found");
            return View("Index", _roleManager.Roles);
        }


        public async Task<IActionResult> Update(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            List<IdentityAppUser> members = new List<IdentityAppUser>();
            List<IdentityAppUser> nonMembers = new List<IdentityAppUser>();
            foreach (IdentityAppUser user in _userManager.Users)
            {
                var list = await _userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
                list.Add(user);
            }
            return View("UpdateRole", new IdentityRoleEdit
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            });
        }


        [HttpPost]
        public async Task<IActionResult> Update(IdentityRoleModification model)
        {
            IdentityResult result;
            if (ModelState.IsValid)
            {
                foreach (string userId in model.AddIds ?? new string[] { })
                {
                    IdentityAppUser user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        result = await _userManager.AddToRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                            Errors(result);
                    }
                }
                foreach (string userId in model.DeleteIds ?? new string[] { })
                {
                    IdentityAppUser user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        result = await _userManager.RemoveFromRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                            Errors(result);
                    }
                }
            }

            if (ModelState.IsValid)
                return RedirectToAction(nameof(Index));
            else
                return await Update(model.RoleId);
        }

        // --- END ---* Manage Roles ***********------



        // **************   Start - Edit a useraccount
        public async Task<IActionResult> EditUser(string id)
        {
            IdentityAppUser foundUser = await _userManager.FindByNameAsync(id);

            EditUserViewModel userView = new EditUserViewModel();

            if (foundUser == null)
            {
                userView.NoUserFound = true;
                userView.NoUserFoundMessage = $"Unable to load user with ID '{id}'.";
            }
            else
            {
                userView.NoUserFound = false;
                userView.NoUserFoundMessage = "";
            }

            userView = foundUser;

            return View("EditUser", userView);
        }


        public async Task<IActionResult> EditUser_Partial(string id)
        {
            IdentityAppUser foundUser = await _userManager.FindByNameAsync(id);

            EditUserViewModel userView = new EditUserViewModel();

            if (foundUser == null)
            {
                userView.NoUserFound = true;
                userView.NoUserFoundMessage = $"Unable to load user with ID '{id}'.";
            }
            else
            {
                userView.NoUserFound = false;
                userView.NoUserFoundMessage = "";
            }

            userView = foundUser;

            return PartialView("_EditUser_Partial", userView);
        }


        [HttpPost]
        public async Task<IActionResult> EditUserSave_Partial(EditUserViewModel viewModel)
        {
            IdentityAppUser user = await _userManager.FindByNameAsync(viewModel.UserName);

            if (ModelState.IsValid)
            {
                IdentityResult result = await IdentityUserMergeAndUpdate(user, viewModel);

                if (result.Succeeded)
                {
                    ToastMessageInput("success", "", "Ändringar på Användar-konto Sparad");

                    //return RedirectToAction("ListAllUsers");
                    return Ok();
                }
                else
                {
                    ToastMessageInput("error", "", $"Felmeddelande: {result.Errors}");

                    //return RedirectToAction("EditUser", viewModel);
                    return PartialView("EditUser_Partial", viewModel);
                }
            }
            else
            { return PartialView("EditUser_Partial", viewModel); }

        }


        [HttpPost]
        public async Task<IActionResult> EditUserSave(EditUserViewModel viewModel)
        {
            IdentityAppUser user = await _userManager.FindByNameAsync(viewModel.UserName);

            if (ModelState.IsValid)
            {
                IdentityResult result = await IdentityUserMergeAndUpdate(user, viewModel);

                if (result.Succeeded)
                {
                    ToastMessageInput("success", "", "Ändringar på Användar-konto Sparad");

                    return RedirectToAction("ListAllUsers");
                }
                else
                {
                    ToastMessageInput("error", "", $"Felmeddelande: {result.Errors}");

                    return RedirectToAction("EditUser", viewModel);
                }
            }
            else
            { return View("EditUser", viewModel); }

        }

        // **********  End - Edit a useraccount



        // **********  Start - This is Edit CustomerAccount-details in AdminPanel
        public async Task<IActionResult> EditCustomer(string id)
        {
            IdentityAppUser foundUser = await _userManager.FindByNameAsync(id);

            EditUserViewModel userViewModel = new EditUserViewModel();

            if (foundUser == null)
            {
                userViewModel.NoUserFound = true;
                userViewModel.NoUserFoundMessage = $"Unable to load user with ID '{id}'.";
            }
            else
            {
                userViewModel.NoUserFound = false;
                userViewModel.NoUserFoundMessage = "";
            }

            userViewModel = foundUser;

            return View("EditCustomer", userViewModel);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCustomerSave(EditUserViewModel viewModel)
        {
            IdentityAppUser user = await _userManager.FindByNameAsync(viewModel.UserName);

            if (ModelState.IsValid)
            {
                IdentityResult result = await IdentityUserMergeAndUpdate(user, viewModel);

                if (result.Succeeded)
                {
                    ToastMessageInput("success", "", "Ändringar på Kund-konto Sparad");

                    return RedirectToAction("Customer", "Admin");
                }
                else
                {
                    ToastMessageInput("error", "", $"Felmeddelande: {result.Errors}");

                    return RedirectToAction("EditCustomer", user.UserName);
                }
            }
            else
            { return View("EditCustomer", viewModel); }

        }



        public async Task<IActionResult> EditCustomer_Partial(string id)
        {
            IdentityAppUser foundUser = await _userManager.FindByNameAsync(id);

            EditUserViewModel viewModel = new EditUserViewModel();

            if (foundUser == null)
            {
                viewModel.NoUserFound = true;
                viewModel.NoUserFoundMessage = $"Unable to load user with ID '{id}'.";
            }
            else
            {
                viewModel.NoUserFound = false;
                viewModel.NoUserFoundMessage = "";
            }

            viewModel = foundUser;

            return PartialView("_EditCustomer_Partial", viewModel);
        }


        //[HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCustomerSave_Partial(EditUserViewModel viewModel)
        {
            IdentityAppUser user = await _userManager.FindByNameAsync(viewModel.UserName);

            if (ModelState.IsValid)
            {
                IdentityResult result = await IdentityUserMergeAndUpdate(user, viewModel);

                if (result.Succeeded)
                {
                    ToastMessageInput("success", "", "Ändringar på Kund-konto Sparad");

                    return RedirectToAction("ManageCustomer", "Admin", new { id = viewModel.UserName });
                    //return Ok();
                    //RedirectToAction("Customer", "Admin");
                }
                else
                {
                    ToastMessageInput("error", "", $"Felmeddelande: {result.Errors}");

                    //return PartialView("_EditCustomer_Partial", viewModel);
                    return RedirectToAction("ManageCustomer", "Admin", new { id = viewModel.UserName });
                }
            }
            else
            {
                return RedirectToAction("ManageCustomer", "Admin", new { id = viewModel.UserName });
                //return PartialView("_EditCustomer_Partial", viewModel);
            }

        }



        // ************* End - AdminPanel edit customer




        // ***** -- START - Take info from form, insert into user-object and update.

        public async Task<IdentityResult> IdentityUserMergeAndUpdate(IdentityAppUser user, EditUserViewModel viewModel)
        {
            user.FirstName = viewModel.FirstName;
            user.LastName = viewModel.LastName;
            user.Email = viewModel.Email;
            user.PhoneNumber = viewModel.PhoneNumber;
            user.Address = viewModel.Address;
            user.Postcode = viewModel.Postcode;
            user.City = viewModel.City;
            user.ExtraInfoTextarea = viewModel.ExtraInfoTextarea;

            var result = await _userManager.UpdateAsync(user);

            return result;
        }
        // ***** -- END - Take info from form, insert into user-object and update.


        // --**********----- Start -- SaveChanged userinfo separate method
        //public async Task<IActionResult> SaveTheChangedUserInfo(
        //    IdentityAppUser user, EditUserViewModel viewModel, string view)
        //{
        //    if (user == null)
        //    {
        //        viewModel.NoUserFound = true;
        //        viewModel.NoUserFoundMessage = $"Unable to find user with ID '{viewModel.Id}'.";

        //        return View(view, viewModel);
        //    }
        //    else
        //    {
        //        viewModel.NoUserFound = false;
        //        viewModel.NoUserFoundMessage = "";
        //    }


        //    var firstName = user.FirstName;
        //    if (viewModel.FirstName != firstName)
        //    {
        //        user.FirstName = viewModel.FirstName;
        //        await _userManager.UpdateAsync(user);
        //    }

        //    //var lastName = user.LastName;
        //    //if (viewModel.LastName != lastName)
        //    //{
        //    //    user.LastName = viewModel.LastName;
        //    //    await _userManager.UpdateAsync(user);
        //    //}

        //    //var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
        //    //if (viewModel.PhoneNumber != phoneNumber)
        //    //{
        //    //    var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, viewModel.PhoneNumber);
        //    //    if (!setPhoneResult.Succeeded)
        //    //    {
        //    //        //StatusMessage = "Unexpected error when trying to set phone number.";
        //    //        return View("EditUser", viewModel);
        //    //    }
        //    //}

        //    //var address = user.Address;
        //    //if (viewModel.Address != address)
        //    //{
        //    //    user.Address = viewModel.Address;
        //    //    await _userManager.UpdateAsync(user);
        //    //}

        //    //var postcode = user.Postcode;
        //    //if (viewModel.Postcode != postcode)
        //    //{
        //    //    user.Postcode = viewModel.Postcode;
        //    //    await _userManager.UpdateAsync(user);
        //    //}

        //    //var city = user.City;
        //    //if (viewModel.City != city)
        //    //{
        //    //    user.City = viewModel.City;
        //    //    await _userManager.UpdateAsync(user);
        //    //}

        //    //var email = user.Email;
        //    //if (viewModel.Email != email)
        //    //{
        //    //    user.Email = viewModel.Email;
        //    //    await _userManager.UpdateAsync(user);
        //    //}

        //    //var extraInfoTextArea = user.ExtraInfoTextarea;
        //    //if (viewModel.ExtraInfoTextarea != extraInfoTextArea)
        //    //{
        //    //    user.ExtraInfoTextarea = viewModel.ExtraInfoTextarea;
        //    //    await _userManager.UpdateAsync(user);
        //    //}

        //    return Ok("All Done");

        //}
        // --**********----- END -- SaveChanged userinfo separate method




        // ---  ToastMessage Handler and show


        public void ToastMessageShow()
        {
            if (TempData["ToastMessage"] != null) // If message is set. Set ViewBags, to display in returned view 
            {
                ViewBag.ToastType = TempData["ToastType"];
                ViewBag.ToastTitle = TempData["ToastTitle"];
                ViewBag.ToastMessage = TempData["ToastMessage"];

                TempData["ToastMess"] = null;
            }
        }


        public void ToastMessageInput(string type = null, string title = null, string message = null)
        {
            TempData["ToastType"] = type; // Types can only be success, warning or error
            TempData["ToastTitle"] = title;
            TempData["ToastMessage"] = message;

            // Put the code-line below in views where you want toastmessages "popups" /Eric R
            // <partial name="_ToastHandlerPartial" /> 
        }


    }


}

