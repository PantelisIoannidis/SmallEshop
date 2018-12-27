using System;
using System.Collections.Generic;
using System.Text;

namespace SmallEshop.Core.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int BasketId { get; set; }

        public Address Address { get; set; }
        public int AddressId { get; set; }

        public List<Item> Items { get; set; }

        public decimal TotalBasketPrice { get; set; }
        public int TotalQuantity { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal Discount { get; set; }

        public DateTime? StoredAt { get; set; }
        public DateTime? ShippedAt { get; set; }
    }
}
