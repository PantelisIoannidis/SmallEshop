using System;
using System.Collections.Generic;
using System.Text;

namespace SmallEshop.Core.Models
{
    public class ItemImage
    {
        public int ItemImageId { get; set; }
        public int ItemId { get; set; }
        public string ImageName { get; set; }

        public bool DefaultImage { get; set; }
        public string PhotoUrl { get; set; }
        public string PhotoThumbnailUrl { get; set; }
        public string PhotoDescription { get; set; }
    }
}
