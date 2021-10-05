using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly ShopContext shopContext;

        public UserController(UserManager<User> userManager, ShopContext shopContext)
        {
            this.userManager = userManager;
            this.shopContext = shopContext;
        }

        public IActionResult Index()
        {
            var users = userManager.Users.ToList();
            return View(users);
        }

        public async Task<IActionResult> CreateOrUpdate(string id)
        {
            if (id!=null)
            {
                var user = await userManager.FindByIdAsync(id);
                return View(user);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrUpdate(User user,string password)
        {
            if (ModelState.IsValid)
            {
                if (user.Id ==null)
                {
                    var result = await userManager.CreateAsync(new User {UserName=user.UserName,Email = user.Email},password);

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
                else
                {
                    var oldUser = await userManager.FindByIdAsync(user.Id);
                    var code = await userManager.GenerateChangeEmailTokenAsync(oldUser, user.Email);
                    var result = await userManager.ChangeEmailAsync(oldUser,user.Email,code);
                    IdentityResult pawwrodRes = default(IdentityResult);
                    if (!string.IsNullOrEmpty(password))
                    {
                        var passwrodCode = await userManager.GeneratePasswordResetTokenAsync(oldUser);
                        pawwrodRes = await userManager.ResetPasswordAsync(oldUser, passwrodCode, password);
                    }
                    var nameRes = await userManager.SetUserNameAsync(oldUser, user.UserName);
                    if (result.Succeeded &&  nameRes.Succeeded)
                    {
                        return RedirectToAction("Index");

                    }
                    else
                    {
                        foreach (var error in result.Errors.Concat(nameRes.Errors))
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
             
                
            }

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user==null)
            {
                return NotFound();
            }

            shopContext.Orders.ToList().RemoveAll(x => x.UserId == user.Id);
            await shopContext.SaveChangesAsync();
            await userManager.DeleteAsync(user);

            return RedirectToAction("Index");
        }
    }
}
