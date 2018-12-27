using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<BasketSummary> logger;

        public BasketSummary(IBasketService basketService,
                        ILogger<BasketSummary> logger)
        {
            this.basketService = basketService;
            this.logger = logger;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            logger.LogInformation("- Begin- InvokeAsync "+DateTime.Now.ToString());
            var itemsCount =
            await basketService
                        .Basket
                        .GetTotalQuantityAsync(basketService.BasketId);
            logger.LogInformation("- End  - InvokeAsync " + DateTime.Now.ToString());
            return View(itemsCount);
           
        }
    }
}
