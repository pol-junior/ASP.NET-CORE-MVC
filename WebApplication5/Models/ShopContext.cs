using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Models
{
    public class ShopContext : IdentityDbContext
    {

        public  DbSet<Order> Orders { get; set; }
        public  DbSet<Bicycle> Bicycles { get; set; }
        public ShopContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();           
        }

    }
}
