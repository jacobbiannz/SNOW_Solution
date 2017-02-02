using AutoMapper;
using SNOW_Solution.Models;
using SNOW_Solution.ViewModels;
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
                .ForMember(d => d.ProductID, opt => opt.MapFrom(s => s.Id))
                .ReverseMap();
        }
    }
}