using System;
using System.Collections.Generic;
using System.Text;

namespace SmallEshop.Core.Dtos
{
    public class CategoryDto
    {
        public CategoryDto()
        {
            Items = new List<ItemDto>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public List<ItemDto> Items { get; set; }
    }
}
