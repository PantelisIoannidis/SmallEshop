using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmallEshop.Core.Models
{
    public class Item
    {
        public Item()
        {
            ItemImages = new List<ItemImage>();
        }

        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }

        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public float? Width { get; set; }
        public float? Height { get; set; }
        public float? Length { get; set; }
        public int? PackageType { get; set; }
        public float Weight { get; set; }
        public int WarehouseAddressId{ get; set; }

        public int ItemImagesId { get; set; }
        public List<ItemImage> ItemImages { get; set; }

    }
}
