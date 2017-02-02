using AutoMapper;
using Snow.Service.Interface;
using SNOW_Solution.Models;
using SNOW_Solution.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SNOW_Solution.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IImageService _imageService;
        private readonly IDefaultService _defaultService;

        public ProductController(IProductService productService, IImageService imageService, IDefaultService defaultService)
        {
            _productService = productService;
            _imageService = imageService;
            _defaultService = defaultService;
        }

        public ActionResult Index(ProductVM product =null)
        {
            
            IEnumerable<Product> _Products;
            IEnumerable<Brand> _Brands;
            IEnumerable<Category> _Categories;
            IEnumerable<Store> _Stores;
            IEnumerable<Company> _Companies;
            _Products = _productService.GetProducts(product.Name).ToList();
            _Brands = _defaultService.GetBrands(product.BrandId).ToList();
            _Categories = _defaultService.GetCategories(product.CategoryId).ToList();
            _Stores = _defaultService.GetStores(product.StoreId).ToList();
            _Companies = _defaultService.GetCompanies(product.CategoryId).ToList();


            var subscriberVM = new SubScriberVM
            {
                Products = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductVM>>(_Products),
                Categories = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryVM>>(_Categories),
                Stores = Mapper.Map<IEnumerable<Store>, IEnumerable<StoreVM>>(_Stores),
                Brands = Mapper.Map<IEnumerable<Brand>, IEnumerable<BrandVM>>(_Brands),
                Companies = Mapper.Map<IEnumerable<Company>, IEnumerable<CompanyVM>>(_Companies),
            };

            
            return View(subscriberVM);
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