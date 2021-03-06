﻿using System.Collections.Generic;
using System.Threading.Tasks;
using SmallEshop.Core.Models;

namespace SmallEshop.Core.Services
{
    public interface IBasket
    {
        Task<int> AddAnItemToBasketAsync(string basketId, int itemId);
        Task<int> AddToBasketOrEditAsync(string basketId, int itemId, int amount);
        Task<int> ClearBasketAsync(string basketId);
        Task<List<BasketItem>> GetBasketItemsAsync(string basketId);
        Task<int> GetTotalQuantityAsync(string basketId);
        Task<int> RemoveAnItemFromBasketAsync(string basketId, int itemId);
        Task<int> RemoveItemsFromBasketAsync(string basketId, int itemId, int amount);
        Task MigrateBasket(string currentBasketId, string newBasketId);
    }
}