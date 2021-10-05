using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    [Authorize(Roles ="God")]
    public class AdminController : Controller
    {
        private ShopContext shopContext;

        public AdminController(ShopContext shopContext)
        {
            this.shopContext = shopContext;
        }

        public IActionResult Index()
        {
            return View(shopContext.Bicycles.ToList());
        }

        public IActionResult Create(int ? id)
        {
            if (id != null) return View(shopContext.Bicycles.Find(id));

            return View();
        }

        [HttpPost]
        public IActionResult Create(Bicycle bicycle)
        {

            if (ModelState.IsValid)
            {

                bicycle.Discripton = "none";
                if (bicycle.BicycleID == 0) shopContext.Bicycles.Add(bicycle);
                else shopContext.Bicycles.Update(bicycle);

                shopContext.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            shopContext.Remove(shopContext.Bicycles.Find(id));
            shopContext.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
