using SmallEshop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallEshop.Web.ViewModels
{
    public class DetailsViewModel
    {
        public DetailsViewModel()
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

        public int ItemImagesId { get; set; }
        public List<ItemImage> ItemImages { get; set; }

        public string ReturnUrl { get; set; }
    }
}
