using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using SmallEshop.Core.Dtos;
using SmallEshop.Core.Models;
using SmallEshop.Core.Repositories;
using SmallEshop.Core.Utilities;
using SmallEshop.Web.Models;
using SmallEshop.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SmallEshop.Web.Services
{
    public class GetCatalogDataService : IGetCatalogDataService
    {
        private readonly ILoggerFactory logger;
        private readonly IItemRepository itemRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IBrandRepository brandRepository;
        private readonly IMapper mapper;

        public GetCatalogDataService(ILoggerFactory logger,
            IItemRepository itemRepository,
            ICategoryRepository categoryRepository,
            IBrandRepository brandRepository,
            IMapper mapper
            )
        {
            this.logger = logger;
            this.itemRepository = itemRepository;
            this.categoryRepository = categoryRepository;
            this.brandRepository = brandRepository;
            this.mapper = mapper;
        }

        public async Task<List<ItemDto>> GetASampleOfItemsASync()
        {
            var itemsDb = await itemRepository.GetAllItemsAsync();
            var items = mapper.Map<List<ItemDto>>(itemsDb);
            return items;
        }

        public async Task<DetailsViewModel> ItemDetailsAsync(int itemId)
        {
            Expression<Func<Item, bool>> expression = LinqExpressions.GetAnItemById(itemId);
            List<Item> itemsDb = await itemRepository.GetAllItemsWhereAsync(expression);
            var items = mapper.Map<List<DetailsViewModel>>(itemsDb);
            return items.FirstOrDefault();
        }

        public async Task<ItemsListViewModel> PrepareListItemsAsync(int pageIdx=1, int pageSize= AppConstants.ItemsPerPage, int? brandId=null, int? categoryId=null)
        {
            Expression<Func<Item, bool>> expression = LinqExpressions.PrepareListItemsFilter(brandId, categoryId);

            var totalItems = itemRepository.GetCountAllItemsWhere(expression);

            Pager pager = new Pager(totalItems, pageIdx, pageSize);

            List<Item> items = await itemRepository.GetAllItemsWhereAsync(expression, pager.Skip, pageSize);

            var model = new ItemsListViewModel() {
                Items = mapper.Map<List<ItemDto>>(items),
                Brands = await PrepareBandsListBoxAsync(),
                Categories = await PrepareCategoriesListBoxAsync(),
                Pager = pager,
                ChoosedBrandId = brandId??0,
                ChoosedCategoryId = categoryId??0,
                TotalItems=totalItems
            };

            return model;
        }

        public async Task<List<SelectListItem>> PrepareBandsListBoxAsync()
        {
            var brands = await brandRepository.ListAllAsync();

            var items = new List<SelectListItem>();

            items.Add(new SelectListItem() {
                Value =null,
                Text ="All",
                Selected =true});

            foreach (Brand brand in brands)
                items.Add(new SelectListItem() {
                    Value=brand.BrandId.ToString(),
                    Text=brand.BrandName});

            return items;
        }

        public async Task<List<SelectListItem>> PrepareCategoriesListBoxAsync()
        {
            var categories = await categoryRepository.ListAllAsync();

            var items = new List<SelectListItem>();

            items.Add(new SelectListItem() {
                Value=null,
                Text="All",
                Selected=true
            });

            foreach (Category category in categories)
                items.Add(new SelectListItem() {
                    Value=category.CategoryId.ToString(),
                    Text=category.CategoryName
                });

            return items;
        }
    }
}
