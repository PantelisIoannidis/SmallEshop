using Microsoft.AspNetCore.Mvc;
using SmallEshop.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallEshop.Web.Components
{
    public class BasketSummary : ViewComponent
    {
        private readonly IBasketService basketService;

        public BasketSummary(IBasketService basketService)
        {
            this.basketService = basketService;
        }

        public IViewComponentResult Invoke()
        {
            var itemsCount = basketService
                        .Basket
                        .GetTotalQuantity(basketService.BasketId);
            return View(itemsCount);
        }
    }
}
