using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SmallEshop.Core.Models;
using SmallEshop.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallEshop.Web.Services
{
    public class BasketService : IBasketService
    {
        private readonly IServiceProvider services;

        public string BasketId { get; set; }
        public List<BasketItem> BasketItems {get;set;}
        public IBasket Basket { get; set; }

        public BasketService(IBasket Basket, IServiceProvider services)
        {
            this.Basket = Basket;
            this.services = services;

            PrepareBasketId();
        }

        private void PrepareBasketId()
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var ses = session.GetString("BasketId");
            BasketId = ses ?? Guid.NewGuid().ToString();
            session.SetString("BasketId", BasketId);
        }

    }
}
