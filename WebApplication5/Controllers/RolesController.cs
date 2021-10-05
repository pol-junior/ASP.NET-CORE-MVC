using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Models;
using WebApplication5.Models.ViewModels;

namespace WebApplication5.Controllers
{
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;

        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public IActionResult Create() => View();
        public IActionResult Index() => View(roleManager.Roles.ToList());
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                IdentityResult result = await roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

            }
            return View("Create",name);    
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var role = await roleManager.FindByIdAsync(id);
                if (role==null)
                {
                    return NotFound();
                }
                 await roleManager.DeleteAsync(role);
            }
            return RedirectToAction("Index");
        }

        public IActionResult UserList() => View(userManager.Users.ToList());

        public async Task<IActionResult> Edit(string id)
        {
            if (!string.IsNullOrEmpty(id)) 
            {
                var user = await userManager.FindByIdAsync(id);
                if (user!=null)
                {
                    var userRoles = await userManager.GetRolesAsync(user);
                    return View(new ChangeRoleViewModel
                    {
                        UserId = id,
                        AllRoles = roleManager.Roles.ToList(),
                        UserRoles = userRoles,
                        UserName = user.UserName
                    }) ;

                }
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string userId, List<string> roles)
        {

          
            var user = await userManager.FindByIdAsync(userId);
            if (user!=null)
            {
                var userRoles = await userManager.GetRolesAsync(user);
                var addedRoles = roles.Except(userRoles);
                var removedRoles = userRoles.Except(roles);

                await userManager.RemoveFromRolesAsync(user,removedRoles);
                await userManager.AddToRolesAsync(user, addedRoles);
                return RedirectToAction("UserList");
            }
            return NotFound();
        }

    }
}
