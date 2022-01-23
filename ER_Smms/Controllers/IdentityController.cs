using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ER_Smms.Models;
using ER_Smms.Models.ViewModels;
using ER_Smms.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ER_Smms.Controllers
{
    [Authorize]//(Roles = "Admin")]
    public class IdentityController : Controller
    {
        private RoleManager<IdentityRole> roleManager;
        private UserManager<IdentityAppUser> userManager;

        public IdentityController(RoleManager<IdentityRole> roleMgr, UserManager<IdentityAppUser> userMrg)
        {
            roleManager = roleMgr;
            userManager = userMrg;
        }

        public ViewResult Index() => View(roleManager.Roles);



        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }


        public IActionResult Create() => View("CreateRole");


        [HttpPost]
        public async Task<IActionResult> Create([Required] string name)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await roleManager.CreateAsync(new IdentityRole(name));
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
            IdentityRole role = await roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await roleManager.DeleteAsync(role);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            }
            else
                ModelState.AddModelError("", "No role found");
            return View("Index", roleManager.Roles);
        }


        public async Task<IActionResult> Update(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);
            List<IdentityAppUser> members = new List<IdentityAppUser>();
            List<IdentityAppUser> nonMembers = new List<IdentityAppUser>();
            foreach (IdentityAppUser user in userManager.Users)
            {
                var list = await userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
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
                    IdentityAppUser user = await userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        result = await userManager.AddToRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                            Errors(result);
                    }
                }
                foreach (string userId in model.DeleteIds ?? new string[] { })
                {
                    IdentityAppUser user = await userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        result = await userManager.RemoveFromRoleAsync(user, model.RoleName);
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



        /// <returns>Returns a string with:
        /// EMPTY = empty roleslist, adding Role Admin.
        /// ERRORCouldNotMakeAdmin = something went wrong when creating role "Admin"
        /// ROLEExist = there is 1 or more roles
        /// </returns>
        public async Task<IActionResult> IsRolesEmpty() // If roles are empty, create "Admin"
        {

            string existOrCreateAdmin; // EMPTY = empty roleslist, adding Role Admin. 
                                       // ERRORCouldNotMakeAdmin = something went wrong when creating role "Admin"
                                       // ROLEExist = there is 1 or more roles

            int nrOfRoles = 0;

            foreach (var role in roleManager.Roles)
            {
                nrOfRoles++;
            }

            if (nrOfRoles == 0)
            {
                string roleName = "Admin";
                IdentityResult result = await roleManager.CreateAsync(new IdentityRole(roleName));
                string roleName2 = "User";
                IdentityResult result2 = await roleManager.CreateAsync(new IdentityRole(roleName2));

                if (result.Succeeded)
                { existOrCreateAdmin = "EMPTY"; }
                else
                {
                    Errors(result);
                    existOrCreateAdmin = "ERRORCouldNotMakeAdmin";
                    ViewBag.Mess = "ERRORCouldNotMakeAdmin";
                }
                return RedirectToAction("Index", "People", new { checkIsDoneResult = existOrCreateAdmin });
            }

            existOrCreateAdmin = "ROLEExist";

            return RedirectToAction("Index", "People", new { checkIsDoneResult = existOrCreateAdmin });
        }



    }


}



























// ER Codes