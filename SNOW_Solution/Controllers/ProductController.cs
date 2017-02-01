using AutoMapper;
using Snow.Service.Interface;
using SNOW_Solution.Models;
using SNOW_Solution.Repository;
using SNOW_Solution.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SNOW_Solution.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IImageService _imageService;

        public ProductController(IProductService productService, IImageService imageService)
        {
            _productService = productService;
            _imageService = imageService;
        }

        public ActionResult Index(string product =null)
        {
            IEnumerable<ProductVM> viewModelProducts;
            IEnumerable<Product> Products;

            Products = _productService.GetProducts(product).ToList();

            viewModelProducts = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductVM>>(Products);
            return View(viewModelProducts);
        }


        // POST: Items/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(ProductVM productVM)
        {
            if (ModelState.IsValid)
            {
                if (productVM != null && productVM.Photos != null)
                {
                    var prod = Mapper.Map<ProductVM, Product>(productVM);
                    prod.BrandId = 1;
                    prod.CategoryId = 1;
                    prod.CompanyId = 1;
                    prod.StoreId = 1;
                    
                    _productService.CreateProduct(prod);
                    foreach (var bin in productVM.Photos)
                    {
                        var image = new Image()
                        {
                            Photo = bin,
                            Name = prod.Name
                        };
                        _imageService.CreateImage(image);
                        _imageService.SaveImage();
                        prod.AllImages.Add(image);
                    }
                    _productService.SaveProduct();
                }

                
            }
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Insert(Product obj)
        {
            _productService.CreateProduct(obj);
            return View();
        }

        public ActionResult Edit(int id)
        {
            var existing = _productService.GetProduct(id);
            return View(existing);
        }

        public ActionResult Details(int id)
        {
            var existing = _productService.GetProduct(id);
            var viewModelProduct = Mapper.Map<Product,ProductVM>(existing);
            return View(viewModelProduct);
        }


        public ActionResult ConfirmDelete(int id)
        {
            var existing = _productService.GetProduct(id);
            return View(existing);
        }


        public ActionResult RenderImage(int id)
        {
            var image = _imageService.GetImage(id);

            byte[] photoBack = image.Photo;

            return File(photoBack, "image/png");
        }

    }
}