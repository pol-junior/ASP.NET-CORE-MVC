using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class OrderController : Controller
    {
        private readonly ShopContext shopContext;
        private readonly UserManager<User> userManager;

        public OrderController(ShopContext shopContext, UserManager<User> userManager)
        {
            this.shopContext = shopContext;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            
            return View(shopContext.Orders.Include(x => x.Bicycle).Where(x => x.UserId == user.Id).ToList());
        }
    }
}
