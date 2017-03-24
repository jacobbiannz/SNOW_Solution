using AutoMapper;
using Snow.Model;
using Snow.Model.Models;
using Snow.Web.ViewModel;
using Snow.Web.ViewModels;
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
            cfg.CreateMap<ImageInfo, ImageInfoVM>()
              .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
             .ForMember(d => d.ContentType, opt => opt.MapFrom(s => s.ContentType))
             .ForMember(d => d.IsSelected, opt => opt.MapFrom(s => s.IsSelected))
             .ForMember(d => d.IsMain, opt => opt.MapFrom(s => s.IsMain))
             .ForMember(d => d.ProductId, opt => opt.MapFrom(s => s.ProductId))
             .ReverseMap();

            cfg.CreateMap<Product, ProductVM>()
                .ForMember(d => d.ProductId, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.CategoryDescription, opt => opt.MapFrom(s => s.MyCategory.Name))
                .ForMember(d => d.MarketPrice, opt =>opt.MapFrom(s => s.MarketPrice))
                .ForMember(d => d.StockPrice, opt => opt.MapFrom(s => s.StockPrice))
                .ForMember(d => d.ImageInfos, opt => opt.MapFrom(s => s.AllImageInfos))
                .ForMember(d => d.IsDeleted, opt => opt.MapFrom(s => s.IsDeleted))
                .ReverseMap();

            cfg.CreateMap<Brand, BrandVM>()
               .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
              .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
              .ForMember(d => d.CompanyId, opt => opt.MapFrom(s => s.CompanyId))
              .ForMember(d => d.CompanyName, opt => opt.MapFrom(s => s.MyCompany.Name))
              .ReverseMap();

            cfg.CreateMap<Category, CategoryVM>()
              .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
              .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
              .ForMember(d => d.CompanyId, opt => opt.MapFrom(s => s.CompanyId))
              .ForMember(d => d.CompanyName, opt => opt.MapFrom(s => s.MyCompany.Name))
              .ReverseMap();

            cfg.CreateMap<Size, SizeVM>()
              .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
             .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
             .ForMember(d => d.CategoryId, opt => opt.MapFrom(s => s.CategoryId))
             .ForMember(d => d.CategoryName, opt => opt.MapFrom(s => s.MyCategory.Name))
             .ReverseMap();

            cfg.CreateMap<Store, StoreVM>()
               .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.PhoneNumber, opt => opt.MapFrom(s => s.PhoneNumber))
                .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Email))
                .ForMember(d => d.AddressLine1, opt => opt.MapFrom(s => s.AddressLine1))
                .ForMember(d => d.AddressLine2, opt => opt.MapFrom(s => s.AddressLine2))
                .ForMember(d => d.City, opt => opt.MapFrom(s => s.City))
                .ForMember(d => d.Country, opt => opt.MapFrom(s => s.Country))
                .ForMember(d => d.CompanyId, opt => opt.MapFrom(s => s.CompanyId))
                .ForMember(d => d.CompanyName, opt => opt.MapFrom(s => s.MyCompany.Name))
                .ReverseMap();

            cfg.CreateMap<Country, CountryVM>()
             .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
             .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
             .ForMember(d => d.Code, opt => opt.MapFrom(s => s.Code))
             .ForMember(d => d.Tax, opt => opt.MapFrom(s => s.Tax))
             .ReverseMap();

            cfg.CreateMap<RegionState, RegionStateVM>()
            .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
            .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
            .ForMember(d => d.CountryId, opt => opt.MapFrom(s => s.CountryId))
            .ForMember(d => d.CountryName, opt => opt.MapFrom(s => s.MyCountry.Name))
            .ReverseMap();

            cfg.CreateMap<Company, CompanyVM>()
            .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
            .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
            .ForMember(d => d.PhoneNumber, opt => opt.MapFrom(s => s.PhoneNumber))
            .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Email))
            .ForMember(d => d.AddressLine1, opt => opt.MapFrom(s => s.AddressLine1))
            .ForMember(d => d.AddressLine2, opt => opt.MapFrom(s => s.AddressLine2))
            .ForMember(d => d.City, opt => opt.MapFrom(s => s.City))
            .ForMember(d => d.Country, opt => opt.MapFrom(s => s.Country))
            .ReverseMap();

            cfg.CreateMap<PaymentType, PaymentTypeVM>()
              .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
              .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description))
              .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
              .ForMember(d => d.CompanyId, opt => opt.MapFrom(s => s.CompanyId))
              .ForMember(d => d.CompanyName, opt => opt.MapFrom(s => s.MyCompany.Name))
              .ReverseMap();

            cfg.CreateMap<Inventory, InventoryVM>()
              .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
              .ForMember(d => d.Quantity, opt => opt.MapFrom(s => s.Quantity))
              .ForMember(d => d.StoreId, opt => opt.MapFrom(s => s.StoreId))
              .ForMember(d => d.StoreName, opt => opt.MapFrom(s => s.MyStore.Name))
              .ForMember(d => d.ProductId, opt => opt.MapFrom(s => s.ProductId))
              .ForMember(d => d.ProductName, opt => opt.MapFrom(s => s.MyProduct.Name))
              .ForMember(d => d.SizeId, opt => opt.MapFrom(s => s.SizeId))
              .ForMember(d => d.SizeName, opt => opt.MapFrom(s => s.MySize.Name))
              .ReverseMap();

            cfg.CreateMap<Image, ImageVM>()
             .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
             .ForMember(d => d.MyImageInfo, opt => opt.MapFrom(s => s.MyImageInfo))
             .ReverseMap();
        }
    }
}