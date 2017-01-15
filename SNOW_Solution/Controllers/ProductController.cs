using AutoMapper;
using Snow.Service.Interface;
using SNOW_Solution.Models;
using SNOW_Solution.Repository;
using SNOW_Solution.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SNOW_Solution.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        public ActionResult Index(string product =null)
        {
            IEnumerable<ProductVM> viewModelProducts;
            IEnumerable<Product> Products;

            Products = productService.GetProducts(product).ToList();

            viewModelProducts = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductVM>>(Products);
            return View(viewModelProducts);
        }

        public ActionResult New()
        {
            return View();
        }

        public ActionResult Insert(Product obj)
        {
            productService.CreateProduct(obj);
            return View();
        }

        public ActionResult Edit(int id)
        {
            var existing = productService.GetProduct(id);
            return View(existing);
        }

        public ActionResult Details(int id)
        {
            var existing = productService.GetProduct(id);
            var viewModelProduct = Mapper.Map<Product,ProductVM>(existing);
            return View(viewModelProduct);
        }


        public ActionResult ConfirmDelete(int id)
        {
            var existing = productService.GetProduct(id);
            return View(existing);
        }


    }
}