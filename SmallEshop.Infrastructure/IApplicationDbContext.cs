using Microsoft.EntityFrameworkCore;
using SmallEshop.Core.Models;

namespace SmallEshop.Infrastructure
{
    public interface IApplicationDbContext
    {
        DbSet<Brand> CatalogBrands { get; set; }
        DbSet<Category> CatalogCategories { get; set; }
        DbSet<Item> CatalogItems { get; set; }
    }
}