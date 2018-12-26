using System;
using System.Collections.Generic;
using System.Text;

namespace SmallEshop.Core.Models
{
    public class Category
    {
        public Category()
        {
            Items = new List<Item>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public List<Item> Items { get; set; }
    }
}
