using Microsoft.EntityFrameworkCore;
using SmallEshop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallEshop.Infrastructure.EntityConfigurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Category> builder)
        {
            builder.Property(p => p.CategoryName).IsRequired();

            builder.HasKey(k => k.CategoryId);
            builder.HasMany(c => c.Items)
                .WithOne(c => c.Category);

        }
    }
}
