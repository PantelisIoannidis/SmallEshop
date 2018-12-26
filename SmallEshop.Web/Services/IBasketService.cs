using System.Collections.Generic;
using SmallEshop.Core.Models;
using SmallEshop.Core.Services;

namespace SmallEshop.Web.Services
{
    public interface IBasketService
    {
        IBasket Basket { get; set; }
        string BasketId { get; set; }
        List<BasketItem> BasketItems { get; set; }
    }
}