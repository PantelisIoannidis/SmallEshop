using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmallEshop.Core.Dtos;
using SmallEshop.Core.Models;
using SmallEshop.Core.Repositories;
using SmallEshop.Web.Models;
using SmallEshop.Web.Services;

namespace SmallEshop.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IGetCatalogDataService getCatalogDataService;
        private readonly IMapper mapper;

        public HomeController(ILogger<HomeController> logger,
                            IGetCatalogDataService getCatalogDataService,
                            IMapper mapper)
        {
            this.logger = logger;
            this.getCatalogDataService = getCatalogDataService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var items = await getCatalogDataService.GetASampleOfItemsASync();
            return View(items);      
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
                            );

            return LocalRedirect(returnUrl);
        }
    }
}
