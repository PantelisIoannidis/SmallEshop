using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using SmallEshop.Web.ViewModels;

namespace SmallEshop.Web.Services
{
    public interface IGetCatalogDataService
    {
        Task<DetailsViewModel> ItemDetailsAsync(int itemId);
        Task<List<SelectListItem>> PrepareBandsListBoxAsync();
        Task<List<SelectListItem>> PrepareCategoriesListBoxAsync();
        Task<ItemsListViewModel> PrepareListItemsAsync(int pageIdx = 1, int pageSize = 10, int? brandId = null, int? categoryId = null);
    }
}