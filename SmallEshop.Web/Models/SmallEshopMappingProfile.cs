using AutoMapper;
using SmallEshop.Core.Dtos;
using SmallEshop.Core.Models;
using SmallEshop.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmallEshop.Web.Models
{
    public class SmallEshopMappingProfile : Profile
    {
        public SmallEshopMappingProfile()
        {
            CreateMap<Brand, BrandDto>()
                .ReverseMap();

            CreateMap<Category, CategoryDto>()
                .ReverseMap();

            CreateMap<ItemImage, ItemImageDto>()
                .ReverseMap();

            CreateMap<Item, ItemDto>()
                .ReverseMap();
            //.ForMember(dest => dest.CatalogBrandId, opt => opt.Ignore());

            CreateMap<Item, DetailsViewModel>()
                .ReverseMap();

            CreateMap<BasketItem, BasketItemDto>()
                .ReverseMap();

            CreateMap<BasketItem, BasketItemViewModel>()
                .ReverseMap();

        }
    }
}
