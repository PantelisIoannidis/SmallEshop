using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmallEshop.Core.Models;
using SmallEshop.Web.Services;
using SmallEshop.Web.ViewModels;

namespace SmallEshop.Web.Controllers
{
    public class BasketController : Controller
    {
        private readonly ILogger<BasketController> logger;
        private readonly IMapper mapper;
        private readonly IBasketService basketService;

        public BasketController(ILogger<BasketController> logger,
                            IMapper mapper,
                            IBasketService basketService)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.basketService = basketService;
        }
        public async Task<IActionResult> Index(string returnUrl="#")
        {
            var basketDb = await basketService.Basket
                        .GetBasketItemsAsync(basketService.BasketId);

            var items = mapper.Map<List<BasketItemViewModel>>(basketDb);
            var basket = new BasketViewModel()
            {
                Items = items,
                returnUrl = returnUrl
            };

            return View(basket);
        }

        public async Task<IActionResult> AddItem(int itemId, string returnUrl = "#")
        {
            await basketService.Basket
                .AddAnItemToBasketAsync(basketService.BasketId, itemId);

            return RedirectToAction(nameof(BasketController.Index), new { returnUrl= returnUrl });
        }

        public async Task<IActionResult> RemoveItem(int itemId, string returnUrl = "#")
        {
            await basketService.Basket
                .RemoveAnItemFromBasketAsync(basketService.BasketId, itemId);

            return RedirectToAction(nameof(BasketController.Index), new { returnUrl = returnUrl });
        }

        public async Task<IActionResult> ClearBasket(string returnUrl = "#")
        {
           await basketService.Basket
                .ClearBasketAsync(basketService.BasketId);

            return RedirectToAction(nameof(BasketController.Index), new { returnUrl = returnUrl });
        }

    }
}