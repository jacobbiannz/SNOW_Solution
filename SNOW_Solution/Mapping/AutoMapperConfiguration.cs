using AutoMapper;
using Snow.Model;
using SNOW_Solution.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Snow.Web.Mapping
{
    public static class AutoMapperConfiguration
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Product, ProductVM>()
                .ForMember(d => d.ProductId, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.CategoryDescription, opt => opt.MapFrom(s => s.MyCategory.Name))
                .ForMember(d => d.MarketPrice, opt =>opt.MapFrom(s => s.MarketPrice))
                .ForMember(d => d.StockPrice, opt => opt.MapFrom(s => s.StockPrice))
                .ReverseMap();

            cfg.CreateMap<Brand, BrandVM>()
               .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
               .ForMember(d => d.BrandId, opt => opt.MapFrom(s => s.Id))
               .ReverseMap();
            cfg.CreateMap<Category, CategoryVM>()
              .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
              .ForMember(d => d.CategoryId, opt => opt.MapFrom(s => s.Id))
              .ReverseMap();
            cfg.CreateMap<Store, StoreVM>()
              .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
              .ForMember(d => d.StoreId, opt => opt.MapFrom(s => s.Id))
              .ReverseMap();
            cfg.CreateMap<Company, CompanyVM>()
             .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
             .ForMember(d => d.CompanyId, opt => opt.MapFrom(s => s.Id))
             .ReverseMap();
        }
    }
}