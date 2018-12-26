using SmallEshop.Core.Models;
using SmallEshop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallEshop.Infrastructure.Repositories
{
    public class BrandRepository : BaseRepository<Brand>, IBrandRepository
    {
        private readonly ApplicationDbContext context;

        public BrandRepository(ApplicationDbContext context)
            :base(context)
        {
            this.context = context;
        }
    }
}
