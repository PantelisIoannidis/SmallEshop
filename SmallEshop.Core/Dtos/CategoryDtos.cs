using System;
using System.Collections.Generic;
using System.Text;

namespace SmallEshop.Core.Dtos
{
    public class CategoryDtos
    {
        public CategoryDtos()
        {
            Items = new List<ItemDtos>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public List<ItemDtos> Items { get; set; }
    }
}
