using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SmallEshop.Core.Models;
using SmallEshop.Core.Services;
using SmallEshop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallEshop.Web.Services
{
    public class BasketService : IBasketService
    {
        private readonly IServiceProvider services;
        private readonly UserManager<IdentityUser> userManager;

        public string BasketId { get; set; }
        public string UserId { get; set; }
        public List<BasketItem> BasketItems {get;set;}
        public IBasket Basket { get; set; }

        public BasketService(IBasket basket, 
                            IServiceProvider services,
                            UserManager<IdentityUser> userManager)
        {
            this.Basket = basket;
            this.services = services;
            this.userManager = userManager;

            PrepareBasketIdAndUserId();
        }
        // With logged in user the baskeId is equal to userId
        // Without logged in user basketId is a random Guid 
        // until the loggin. Then basket migrate to new basketId that equals to userId
        private void PrepareBasketIdAndUserId()
        {
            var httpContextAccessor = services.GetRequiredService<IHttpContextAccessor>();
            ISession session = httpContextAccessor?.HttpContext.Session;
            var user = httpContextAccessor.HttpContext.User;

            // 1. Read the  User Id if the user is logged in
            UserId = userManager.GetUserId(user);

            // 2. Read the session for the current BasketId
            var currentBasketId = session.GetString(AppConstants.BasketId);
            
            // 4. If user is logged in and BasketId isn't the userId
            // make basketid equal to userId and then migrate basket to new basketId 
            if (UserId!=null && currentBasketId != UserId)
            {
                Basket.MigrateBasket(currentBasketId,UserId);
                currentBasketId = UserId;
            }
            // 3. If current BasketId is empty, give a new Guid Id
            BasketId = currentBasketId ?? $"temp_{Guid.NewGuid().ToString()}";
            session.SetString(AppConstants.BasketId, BasketId);

        }

    }
}
