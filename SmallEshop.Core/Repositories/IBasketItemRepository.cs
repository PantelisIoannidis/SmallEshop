using SmallEshop.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmallEshop.Core.Repositories
{
    public interface IBasketItemRepository : IBaseRepository<BasketItem>
    {
        Task<List<BasketItem>> GetBasketItemsAsync(string basketId);
        Task<int> GetBasketCountItemsAsync(string basketId);
        BasketItem GetBasketItem(string basketId, int itemId);
        Task MigrateBasketItems(string currentBasketId, string newBasketId);
    }
}
