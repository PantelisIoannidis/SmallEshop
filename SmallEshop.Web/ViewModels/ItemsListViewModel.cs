using Microsoft.AspNetCore.Mvc.Rendering;
using SmallEshop.Core.Dtos;
using SmallEshop.Core.Models;
using SmallEshop.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmallEshop.Web.ViewModels
{
    public class ItemsListViewModel
    {
        public List<ItemDto> Items { get; set; }
        public List<SelectListItem> Brands { get; set; }
        public List<SelectListItem> Categories { get; set; }

        public int? ChoosedBrandId {get;set;}
        public int? ChoosedCategoryId { get; set; }

        public Pager Pager { get; set; }
        public int TotalItems { get; set; }

        public string ReturnUrl { get; set; }

    }
}
