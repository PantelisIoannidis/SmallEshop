using System;
using System.Collections.Generic;
using System.Text;

namespace SmallEshop.Core.Dtos
{
    public class BrandDto
    {
        public BrandDto()
        {
            Items = new List<ItemDto>();
        }

        public int BrandId { get; set; }
        public string BrandName { get; set; }

        public List<ItemDto> Items { get; set; }
    }
}
