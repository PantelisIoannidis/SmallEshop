using Microsoft.EntityFrameworkCore;
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

        public BasketItemRepository(ApplicationDbContext context)
            : base(context)
        {
            this.context = context;
        }

        public List<BasketItem> GetBasketItems(string basketId)
        {
            return context.BasketItems.Include(i => i.Item).Where(x => x.BasketId == basketId).ToList();
        }
        public BasketItem GetBasketItem(string basketId,int itemId)
        {
            var basketItem = context.BasketItems
                .Include(i => i.Item)
                .Where(x => 
                    x.BasketId == basketId &&
                     x.ItemId == itemId);
            return basketItem.FirstOrDefault();
        }
    }
}
