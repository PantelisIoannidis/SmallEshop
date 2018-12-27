using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SmallEshop.Core.Models;
using SmallEshop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallEshop.Infrastructure.Repositories
{
    public class BasketItemRepository : BaseRepository<BasketItem>, IBasketItemRepository
    {
        private readonly ApplicationDbContext context;
        private readonly ILogger<BasketItemRepository> logger;

        public BasketItemRepository(ApplicationDbContext context,
                                    ILogger<BasketItemRepository> logger)
            : base(context)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<List<BasketItem>> GetBasketItemsAsync(string basketId)
        {
            return await context.BasketItems.Include(i => i.Item).Where(x => x.BasketId == basketId).ToListAsync();
        }
        public async Task<int> GetBasketCountItemsAsync(string basketId)
        {
            return await context.BasketItems
                .Where(x => x.BasketId == basketId)
                .SumAsync(s => s.Quantity);
        }
        public BasketItem GetBasketItem(string basketId,int itemId)
        {
            logger.LogInformation("- Begin-GetBasketItem" + DateTime.Now.ToString());
            var basketItem = context.BasketItems
                .Include(i => i.Item)
                .Where(x => 
                    x.BasketId == basketId &&
                     x.ItemId == itemId);
            logger.LogInformation("- End  -GetBasketItem" + DateTime.Now.ToString());
            return basketItem.FirstOrDefault();
        }

        public async Task MigrateBasketItems(string currentBasketId, string newBasketId)
        {
            logger.LogInformation("- Begin- Migrate     " + DateTime.Now.ToString());
            var basket = context.BasketItems
                    .Where(x => x.BasketId == currentBasketId);
            foreach (var item in basket)
            {
                item.BasketId = newBasketId;
                context.Entry(item).State = EntityState.Modified;
                logger.LogInformation("- loop - Migrate     " + DateTime.Now.ToString());
            }
            logger.LogInformation("- End  - Migrate     " + DateTime.Now.ToString());
            context.SaveChangesAsync().Wait();  
        }
    }
}
