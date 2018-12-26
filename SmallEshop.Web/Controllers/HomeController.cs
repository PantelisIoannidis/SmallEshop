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
        private readonly IMapper mapper;

        public HomeController(ILogger<HomeController> logger,
                            IMapper mapper)
        {
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
              return View();      
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
