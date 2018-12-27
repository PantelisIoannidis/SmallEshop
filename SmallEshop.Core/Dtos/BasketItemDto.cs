using SmallEshop.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmallEshop.Core.Dtos
{
    public class BasketItemDto
    {
        public int BasketItemId { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public string BasketId { get; set; }
        public DateTime? StoredAt { get; set; }
    }
}
