using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SmallEshop.Core.Models;
using SmallEshop.Core.Repositories;
using SmallEshop.Infrastructure;
using SmallEshop.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmallEshop.InFrastructure.Repositories
{
    public class ItemRepository : BaseRepository<Item>, IItemRepository
    {
        private ApplicationDbContext context;
        private readonly ILogger<ItemRepository> logger;

        public ItemRepository(ApplicationDbContext context, 
                    ILogger<ItemRepository> logger)
            :base(context)
        {
            this.context = context;
            this.logger = logger;
        }

        public Item GetItem(int itemId)
        {
            return context.Items
                        .Include(c => c.Brand)
                        .Include(c => c.Category)
                        .Include(c => c.ItemImages)
                        .SingleOrDefault(x => x.ItemId == itemId);

        }

        public List<Item> GetAllItemsWhere(Expression<Func<Item, bool>> expression, int? skip = null, int? take = null)
        {
            var predicate = expression.Compile();

            return context.Items
                        .Include(c => c.Brand)
                        .Include(c => c.Category)
                        .Include(c=>c.ItemImages)
                        .Where(predicate)
                        .Skip(skip ?? 0)
                        .Take(take ?? int.MaxValue)
                        .ToList();
                
        }

        public async Task<List<Item>> GetAllItemsWhereAsync(Expression<Func<Item, bool>> expression, int? skip = null, int? take = null)
        {
            try { 
                var query = await context.Items
                            .Include(c => c.Brand)
                            .Include(c => c.Category)
                            .Include(c => c.ItemImages)
                            .Where(expression)
                            .Skip(skip ?? 0)
                            .Take(take ?? int.MaxValue)
                            .ToListAsync();
                var results = query;
                return results;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
            return null;
        }

        public  int GetCountAllItemsWhere(Expression<Func<Item, bool>> expression)
        {
            var predicate = expression.Compile();

            return context.Items
                        .Include(c => c.Brand)
                        .Include(c => c.Category)
                        .Include(c => c.ItemImages)
                        .Count(predicate);
        }

        public int GetCountAllItems()
        {
            return context.Items.Count();
        }

        public List<Item> GetAllItems(int? skip = null, int? take = null)
        {
            return context.Items
                        .Include(c => c.Brand)
                        .Include(c => c.Category)
                        .Include(c => c.ItemImages)
                        .Skip(skip ?? 0)
                        .Take(take ?? int.MaxValue)
                        .ToList();

        }

        public async Task<List<Item>> GetAllItemsAsync(int? skip = null, int? take = null)
        {
            return await context.Items
                        .Include(c => c.Brand)
                        .Include(c => c.Category)
                        .Include(c => c.ItemImages)
                        .Skip(skip ?? 0)
                        .Take(take ?? int.MaxValue)
                        .AsQueryable()
                        .ToListAsync();

        }
    }
}
