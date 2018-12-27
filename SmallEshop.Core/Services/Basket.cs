using SmallEshop.Core.Models;
using SmallEshop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmallEshop.Core.Services
{
    public class Basket : IBasket
    {
        private readonly IBasketItemRepository basketItemRepository;
        private readonly IItemRepository itemRepository;

        public Basket(IBasketItemRepository basketItemRepository,
                        IItemRepository itemRepository)
        {
            this.basketItemRepository = basketItemRepository;
            this.itemRepository = itemRepository;
        }

        public async Task<int> AddToBasketOrEditAsync(string basketId, int itemId, int amount)
        {
            if (amount <= 0)
                return -1;

            var basketItem = basketItemRepository.GetBasketItem(basketId, itemId);

            if (basketItem != null)
            {
                basketItem.Quantity = amount;
                return await basketItemRepository.UpdateAsync(basketItem);
            }
            else
            {
                var newBasketItem = new BasketItem()
                {
                    Item = itemRepository.GetItem(itemId),
                    Quantity = amount,
                    BasketId = basketId,
                    StoredAt = DateTime.UtcNow
                };
                return await basketItemRepository.AddAsync(newBasketItem);
            } 
        }

        public async Task<int> AddAnItemToBasketAsync(string basketId, int itemId)
        {
            var basketItem = basketItemRepository.GetBasketItem(basketId, itemId);

            if (basketItem != null)
            {
                basketItem.Quantity = basketItem.Quantity+1;
                return await basketItemRepository.UpdateAsync(basketItem);
            }
            else
            {
                var newBasketItem = new BasketItem()
                {
                    Item = itemRepository.GetItem(itemId),
                    Quantity = 1,
                    BasketId = basketId,
                    StoredAt = DateTime.UtcNow
                };
                return  await basketItemRepository.AddAsync(newBasketItem);
            }
        }

        public async Task<int> RemoveAnItemFromBasketAsync(string basketId, int itemId)
        {
            var basketItem = basketItemRepository.GetBasketItem(basketId, itemId);
            if (basketItem != null && basketItem.Quantity > 1)
            {
                basketItem.Quantity = basketItem.Quantity - 1;
                return await basketItemRepository.UpdateAsync(basketItem);
            }
            else
            {
                return await basketItemRepository.DeleteAsync(basketItem);
            }
        }


        public async Task<int> RemoveItemsFromBasketAsync(string basketId,int itemId, int amount)
        {
            if (amount <= 0)
                return -1;

            var basketItem = basketItemRepository.GetBasketItem(basketId, itemId);
            if (basketItem != null && basketItem.Quantity>1)
            {
                basketItem.Quantity = amount;
                return await basketItemRepository.UpdateAsync(basketItem);
            } else
            {
                return await basketItemRepository.DeleteAsync(basketItem);
            }
        }

        public Task<List<BasketItem>> GetBasketItemsAsync(string basketId)
        {
            return basketItemRepository.GetBasketItemsAsync(basketId);
        }

        public Task<int> GetTotalQuantityAsync(string basketId)
        {
            return basketItemRepository.GetBasketCountItemsAsync(basketId);
        }

        public async Task<int> ClearBasketAsync(string basketId)
        {          
            return await basketItemRepository.DeleteWhereAsync(x => x.BasketId == basketId);
        }

        public async Task MigrateBasket(string currentBasketId, string newBasketId)
        {
            await basketItemRepository.MigrateBasketItems(currentBasketId, newBasketId);
        }
    }
}
