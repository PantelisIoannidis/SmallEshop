using System;
using System.Collections.Generic;
using System.Text;

namespace SmallEshop.Core.Models
{
    public class Brand
    {
        public Brand()
        {
            Items = new List<Item>();
        }

        public int BrandId { get; set; }
        public string BrandName { get; set; }

        public List<Item> Items { get; set; }
    }
}
