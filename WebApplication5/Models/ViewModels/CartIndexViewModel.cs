using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Models.ViewModels
{
    public class CartIndexViewModel
    {
        public Cart Cart { set; get; }

        public string ReturnUrl { set; get; }
    }
}
