using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmallEshop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallEshop.Infrastructure.EntityConfigurations
{
    public class ItemImageConfiguration : IEntityTypeConfiguration<ItemImage>
    {
        public void Configure(EntityTypeBuilder<ItemImage> builder)
        {
            builder.Property(p => p.PhotoThumbnailUrl).IsRequired();
            builder.Property(p => p.PhotoUrl).IsRequired();

            builder.HasKey(k => k.ItemImageId);
            
                
        }
    }
}
