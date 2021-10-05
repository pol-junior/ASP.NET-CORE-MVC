using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Extinsions;
using WebApplication5.Models;
using WebApplication5.Models.ViewModels;

namespace WebApplication5.Controllers
{
    public class CartController : Controller
    {
        private ShopContext shopContext;

        public CartController(ShopContext shopContext)
        {           
            this.shopContext = shopContext;
        }

        public IActionResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }

        public IActionResult Add(int id, string returnUrl)
        {
            Bicycle bicycle = shopContext.Bicycles.FirstOrDefault(x => x.BicycleID == id);
            if (bicycle!=null)
            {
                var cart = GetCart();
                cart.AddItem(bicycle,1);
                HttpContext.Session.SetObjectAsJson("Cart", cart);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public IActionResult Remove(int id, string returnUrl)
        {
            var cart = GetCart();
            cart.Remove(shopContext.Bicycles.FirstOrDefault(x => x.BicycleID == id));
            HttpContext.Session.SetObjectAsJson("Cart", cart);
            return RedirectToAction("Index", new { returnUrl });
        }
        private Cart GetCart()
        {
            Cart cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart");
            if (cart==null)
            {
                cart = new Cart();
                HttpContext.Session.SetObjectAsJson("Cart", cart);
            }

            return cart;
        }
    }
}
