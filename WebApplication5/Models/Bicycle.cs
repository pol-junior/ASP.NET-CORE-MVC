using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Models
{
    public class Bicycle
    {   
        [Required]
        public int BicycleID { set; get; }
        public string Discripton { set; get; } = "none";
        public string Name { set; get; }
        public decimal Price { set; get; }
        public string IamgeUrl { set; get; }
        public string Mnufacture { set; get; }
        public int GearsQuantity { set; get; }
        public double WheelDiameter { set; get; }
        public double Weight { set; get; }
        public double FrameSize { set; get; }
    }
}
