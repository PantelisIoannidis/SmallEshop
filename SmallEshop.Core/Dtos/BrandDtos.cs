using System;
using System.Collections.Generic;
using System.Text;

namespace SmallEshop.Core.Dtos
{
    public class BrandDtos
    {
        public BrandDtos()
        {
            Items = new List<ItemDtos>();
        }

        public int BrandId { get; set; }
        public string BrandName { get; set; }

        public List<ItemDtos> Items { get; set; }
    }
}
