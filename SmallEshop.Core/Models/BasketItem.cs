using System;
using System.Collections.Generic;
using System.Text;

namespace SmallEshop.Core.Models
{
    public class BasketItem
    {
        public int BasketItemId { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public string BasketId { get; set; }
        public DateTime? StoredAt { get; set; }
    }
}
