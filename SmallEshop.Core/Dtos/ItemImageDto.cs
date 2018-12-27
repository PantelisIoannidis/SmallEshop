using System;
using System.Collections.Generic;
using System.Text;

namespace SmallEshop.Core.Dtos
{
    public class ItemImageDto
    {
        public int ItemImagesId { get; set; }
        public int ItemId { get; set; }
        public string ImageName { get; set; }

        public bool DefaultImage { get; set; }
        public string PhotoUrl { get; set; }
        public string PhotoThumbnailUrl { get; set; }
        public string PhotoDescription { get; set; }
    }
}
