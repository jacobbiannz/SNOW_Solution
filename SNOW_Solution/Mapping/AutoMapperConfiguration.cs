using AutoMapper;
using SNOW_Solution.Models;
using SNOW_Solution.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SNOW_Solution.Mapping
{
    public static class AutoMapperConfiguration
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Product, ProductVM>()
                .ForMember(d => d.ProductId, opt => opt.MapFrom(s => s.Id))
                .ReverseMap();
            cfg.CreateMap<Brand, BrandVM>()
               .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
               .ReverseMap();
            cfg.CreateMap<Category, CategoryVM>()
              .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
              .ReverseMap();
            cfg.CreateMap<Store, StoreVM>()
              .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
              .ReverseMap();
            cfg.CreateMap<Company, CompanyVM>()
             .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
             .ReverseMap();
        }
    }
}