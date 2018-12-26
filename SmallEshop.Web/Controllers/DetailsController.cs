using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using SmallEshop.Web.Services;
using SmallEshop.Web.ViewModels;

namespace SmallEshop.Web.Controllers
{
    public class DetailsController : Controller
    {
        private readonly IGetCatalogDataService getCatalogDataService;
        private readonly IStringLocalizer<CatalogController> _StringLocalizer;
        private readonly ILogger<CatalogController> logger;
        private readonly IMapper mapper;

        public DetailsController(IGetCatalogDataService getCatalogDataService,
                            IStringLocalizer<CatalogController> _stringLocalizer,
                            ILogger<CatalogController> logger,
                            IMapper mapper)
        {
            this.getCatalogDataService = getCatalogDataService;
            _StringLocalizer = _stringLocalizer;
            this.logger = logger;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Index(DetailsViewModel detailsViewModel)
        {
            if (!ModelState.IsValid)
                return View();
            var item = await getCatalogDataService.ItemDetailsAsync(detailsViewModel.ItemId);
            item.ReturnUrl = /*@"https://" +*/ detailsViewModel.ReturnUrl;
            return View(item);
        }
    }
}