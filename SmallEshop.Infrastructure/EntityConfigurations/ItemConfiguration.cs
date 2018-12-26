using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmallEshop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallEshop.Infrastructure.EntityConfigurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {

        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.Property(p => p.ItemName).IsRequired();
            builder.Property(p => p.ShortDescription).IsRequired();
            //builder.Property(p => p.LongDescription).HasMaxLength(4000);

            builder.HasKey(k => k.ItemId);
            builder.HasOne(c => c.Category)
                .WithMany(c => c.Items);
            builder.HasOne(c => c.Brand)
                .WithMany(c => c.Items);
            builder.HasMany(c => c.ItemImages);
        }
    }
}
