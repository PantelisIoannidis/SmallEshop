using SmallEshop.Core.Models;
using System.Collections.Generic;

namespace SmallEshop.Core.Repositories
{
    public interface IBasketItemRepository : IBaseRepository<BasketItem>
    {
        List<BasketItem> GetBasketItems(string basketId);
        BasketItem GetBasketItem(string basketId, int itemId);
    }
}
