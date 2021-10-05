using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using WebApplication5.Models;
namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ShopContext shopContext;
        private readonly UserManager<User> userManager;
        public HomeController(ShopContext shopContext, UserManager<User> userManager)
        {
            this.shopContext = shopContext;
            this.userManager = userManager;

        }
        public IActionResult Index(bool ? IsComplited)
        {
            ViewBag.IsComplited = false;
            ViewBag.ManufactureContext = shopContext.Bicycles.Select(x=>x.Mnufacture).Distinct();
            ViewBag.FrameSizeContext = shopContext.Bicycles.Select(x=>x.FrameSize).Distinct();
            ViewBag.GearsQuantityContext = shopContext.Bicycles.Select(x => x.GearsQuantity).Distinct();

            return View();
        }

        public IActionResult BicycleList(string  manufactureName, string serchText, double? frameSize, int? gearsQuantity, int  pagenationNum = 20)
        {
            var res = shopContext.Bicycles.ToList();

            if (manufactureName != null && manufactureName != "undefined") res = res.Where(x => x.Mnufacture == manufactureName).ToList();

            if (frameSize != null) res = res.Where(x => x.FrameSize == frameSize).ToList();

            if (gearsQuantity != null) res = res.Where(x => x.GearsQuantity == gearsQuantity).ToList();

            if (pagenationNum != 0 && manufactureName == null && frameSize == null && gearsQuantity == null && serchText == null) res = res.Take(pagenationNum).ToList();

            if (serchText != null ) res = shopContext.Bicycles.Where(x => x.Name.ToLower().Contains(serchText.ToLower())).ToList();

            return PartialView(res);
        }   

        [HttpGet]
        [Authorize]
        public IActionResult Buy(int ? id)
        {
            if(id == null)
            {
                return RedirectToAction("Index");
            }

            var tmp = shopContext.Bicycles.FirstOrDefault(x => x.BicycleID == id);
             return View(tmp);
        }

        [HttpGet]
        public IActionResult Deteils(int ? id)
        {

            if (id != null)  return View(shopContext.Bicycles.Find(id));

            return RedirectToAction("Index");
            
        }

        [HttpPost]
        public async Task<IActionResult> Buy(int  id)
        {

            var user = await userManager.FindByNameAsync(User.Identity.Name);

            if (user!=null)
            {
                await Task.Run(() =>
                {
                    var order = new Order { User = user, UserId = user.Id, BicycleId = id };
                    shopContext.Orders.Add(order);
                    shopContext.SaveChanges();
                    SendToEmail($@"dear {order.User.UserName}, thanks for order!:)", order.User.Email, "typingtestfinalwork@gmail.com", "Qwerty!!!123");
                });

                return RedirectToAction("Index", "Home", new { IsComplited = true });

            }
            else
            {
                return View(id);
            }

        }

        public IActionResult SelectManufacure(string  ManufactureName)
        {
            if (ManufactureName != null)
            {
                return RedirectToAction("Index", "Home", new { manufactureName = ManufactureName });
            }

            return RedirectToAction("Index");
        }

        public IActionResult Serch(string  serchText)
        {
            if (serchText != null)
            {
               return RedirectToAction("Index", "Home", new { serchText = serchText });
            }

            return RedirectToAction("Index");
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
            msg.Body = message;
            smtp.Send(msg);
        }

    }
}
