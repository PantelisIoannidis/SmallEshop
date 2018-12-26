using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using SmallEshop.Web.Models;
using SmallEshop.Web.Services;

namespace SmallEshop.Web.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IGetCatalogDataService getCatalogDataService;
        private readonly IStringLocalizer<CatalogController> _StringLocalizer;
        private readonly ILogger<CatalogController> logger;
        private readonly IMapper mapper;

        public CatalogController(IGetCatalogDataService getCatalogDataService,
                            IStringLocalizer<CatalogController> _stringLocalizer,
                            ILogger<CatalogController> logger,
                            IMapper mapper)
        {
            this.getCatalogDataService = getCatalogDataService;
            _StringLocalizer = _stringLocalizer;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index(int? choosedBrandId, int? choosedCategoryId, int? pageIdx = 1)
        {
            try
            {
                var items = await getCatalogDataService.PrepareListItemsAsync(pageIdx ?? 1, AppConstants.ItemsPerPage, choosedBrandId, choosedCategoryId);
                return View(items);
            }
            catch (Exception ex)
            {
                return View();
            }

        }
    }
}