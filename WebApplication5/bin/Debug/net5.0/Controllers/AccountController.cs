using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using WebApplication5.Models;
using WebApplication5.Models.ViewModels;

namespace WebApplication5.Controllers
{
    public class AccountController : Controller
    {

        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;

        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }

                }
                else
                {
                    ModelState.AddModelError("", "Invalid login and/or password");
                }


            }
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User { UserName = model.UserName, Email = model.Email };
                var result = await userManager.CreateAsync(user,model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        public IActionResult ForgotPassword()
        {
            return View();
        }

        public async Task<IActionResult> VaitForEmail(string email)
        {

            var user = await userManager.FindByEmailAsync(email);
            if (user==null)
            {
                return View("Register");
            }

            user.TwoFactorEnabled = true;
            string code = await userManager.GeneratePasswordResetTokenAsync(user);
            var callBackUrl = Url.Action("ReastPassword", "Account", new {Email=user.Email,Code = code }, protocol: HttpContext.Request.Scheme);
            SendToEmail($"<a href='{callBackUrl}'>link</a>", user.Email, "typingtestfinalwork@gmail.com", "Qwerty!!!123");

            return View();
        }

        public IActionResult ReastPassword(string email,string code =null)
        {
            if (code==null)
            {
                return NotFound();
            }

            return View("ReastPassword", new ResetPasswordViewModel {Email=email,Code=code});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReastPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(resetPasswordViewModel);
            }
            var user = await userManager.FindByEmailAsync(resetPasswordViewModel.Email);
            if (user==null)
            {
                return RedirectToAction("Register");
            }
            var result = await userManager.ResetPasswordAsync(user, resetPasswordViewModel.Code, resetPasswordViewModel.Password);
            if (result.Succeeded)
            {
                await signInManager.PasswordSignInAsync(user, resetPasswordViewModel.Password, false, false);
                return RedirectToAction("Index", "Home");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(resetPasswordViewModel);
        }
        public void SendToEmail(string message, string emailTo, string emaliFrom, string password)
        {
            MailAddress from = new MailAddress(emaliFrom);
            MailAddress to = new MailAddress(emailTo);
            MailMessage msg = new MailMessage(from, to);
            msg.Subject = "Hello, from bicycle shop";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential(emaliFrom, password);
            smtp.EnableSsl = true;
            msg.IsBodyHtml = true;
            msg.Body = message;
            smtp.Send(msg);
        }

    }
}
