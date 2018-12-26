using SmallEshop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallEshop.Web.ViewModels
{
    public class BasketItemViewModel
    {
        public Item Item { get; set; }
        public int Quantity { get; set; }

        public decimal TotalPrice
        {
            get {
                return Item.Price * Quantity;
            }
        }
    }
}
