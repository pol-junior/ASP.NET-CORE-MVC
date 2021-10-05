using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Models
{
    public class Order
    {
        public Order()
        {
            Data = DateTime.Now.ToShortDateString();
            DeliveryAddress = "London";
        }

        public int OrderId { set; get; }
        public string DeliveryAddress { set; get; }
        public int BicycleId { set; get; } 
        public string Data{ set; get; }
        public virtual Bicycle Bicycle { set; get; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

    }   
}       
