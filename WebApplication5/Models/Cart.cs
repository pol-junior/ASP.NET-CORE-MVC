using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Models
{
    public class Cart
    {
        private List<CartLine> cartLines = new List<CartLine>();

        public void AddItem(Bicycle bicycle, int quantity)
        {

            var item = cartLines.FirstOrDefault(x => x.Bicycle.BicycleID == bicycle.BicycleID);
            if (item==null)
            {
                cartLines.Add(new CartLine
                {
                    Bicycle = bicycle,
                    Quantity = quantity
                });
            }
            else
            {
                item.Quantity+=quantity;
            }
        }

        public void Remove(Bicycle bicycle)
        {
            var item = cartLines.FirstOrDefault(x => x.Bicycle.BicycleID == bicycle.BicycleID);
            if (item != null)
            {

                if (item.Quantity == 1)
                {

                    cartLines.RemoveAll(x => x.Bicycle.BicycleID == bicycle.BicycleID);
                }
                else
                {
                    item.Quantity--;
                }

            }
        }

        public decimal GetTotal()=>cartLines.Sum(x => x.Bicycle.Price);

        public IEnumerable<CartLine> Lines => cartLines;

        public void Clear()
        {
            cartLines.Clear();
        }
    }

    public class CartLine
    {
        public Bicycle Bicycle { set; get; }

        public int Quantity { set; get; }
    }
        
        
}
