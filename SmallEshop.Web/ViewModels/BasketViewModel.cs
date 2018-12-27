using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallEshop.Web.ViewModels
{
    public class BasketViewModel
    {
        public List<BasketItemViewModel> Items { get; set; }
        public string returnUrl { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalBasketPrice
        {
            get {
                return (Items.Sum(x => x.TotalPrice) + ShippingCost-Discount);
            }
        }
        public int TotalQuantity
        {
            get
            {
                return Items.Sum(x => x.Quantity);
            }
        }
    }
}
