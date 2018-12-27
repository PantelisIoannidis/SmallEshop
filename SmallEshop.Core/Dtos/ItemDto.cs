using System;
using System.Collections.Generic;
using System.Text;

namespace SmallEshop.Core.Dtos
{
    public class ItemDto
    {
        public ItemDto()
        {
            ItemImages = new List<ItemImageDto>();
        }

        public int ItemId { get; set; }
        public int CatalogItemId { get; set; }
        public string ItemName { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }

        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }

        public int CategoryId { get; set; }
        public CategoryDto Category { get; set; }

        public int BrandId { get; set; }
        public BrandDto Brand { get; set; }

        public int ItemImagesId { get; set; }
        public List<ItemImageDto> ItemImages { get; set; }

    }
}
