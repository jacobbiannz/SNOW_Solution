using AutoMapper;
using Snow.Service;
using Snow.Model;
using Snow.Web.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Snow.Web.ViewModels;
using Snow.Model.Models;

namespace Snow.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IImageService _imageService;
        private readonly ICategoryService _categoryService;
        private readonly IBrandService _brandService;
        private readonly ICompanyService _companyService;
        private readonly IStoreService _StoreService;
        
        public ProductController(IProductService productService, 
                                   IImageService imageService, 
                                   ICategoryService categoryService,
                                   IStoreService storeService,
                                   ICompanyService companyService,
                                   IBrandService brandService
                                   )
        {
            _productService = productService;
            _imageService = imageService;
            _categoryService = categoryService;
            _companyService = companyService;
            _StoreService = storeService;
            _brandService = brandService;
        }

        public ActionResult Index(ProductVM product =null)
        {
            IEnumerable<ProductVM> viewModelProducts;
            IEnumerable<Product> Products;

            Products = _productService.GetProducts(product.Name).ToList();

            viewModelProducts = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductVM>>(Products);
            
            return View(viewModelProducts);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {

            ICollection<Brand> _Brands;
            ICollection<Category> _Categories;
            ICollection<Store> _Stores;
            ICollection<Company> _Companies;


            _Categories = _categoryService.GetCategories().ToList();
            _Brands = _brandService.GetBrands().ToList();
            _Stores = _StoreService.GetStores().ToList();
            _Companies = _companyService.GetCompanies().ToList();

           
            var subscriberVM = new SubscriberVM
            {
                CategoriesVM = Mapper.Map<ICollection<Category>, ICollection<CategoryVM>>(_Categories),
                BrandsVM = Mapper.Map<ICollection<Brand>, ICollection<BrandVM>>(_Brands),
                StoresVM = Mapper.Map<ICollection<Store>, ICollection<StoreVM>>(_Stores),
                CompaniesVM = Mapper.Map<ICollection<Company>, ICollection<CompanyVM>>(_Companies)

            };

            var productVM = new ProductVM();
            productVM.MySubscriberVM = subscriberVM;
            return View(productVM);
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
                    prod.BrandId = productVM.BrandId;
                    prod.CategoryId = productVM.CategoryId;
                    prod.CompanyId = productVM.CompanyId;
                    prod.StoreId = productVM.StoreId;
                    
                    _productService.CreateProduct(prod);
                    foreach (var bin in productVM.Photos)
                    {
                       
                        var image = new Image()
                        {
                            Photo = bin,
                            MyImageInfo = new ImageInfo
                            {
                                Name = prod.Name,
                               
                            }
                        };
                        _imageService.CreateImage(image);
                        _imageService.SaveImage();
                        prod.AllImageInfos.Add(image.MyImageInfo);
                    }
                    _productService.SaveProduct();
                }

                
            }
            return RedirectToAction("Index");
        }
        

        public ActionResult Insert(Product obj)
        {
            _productService.CreateProduct(obj);
            return View();
        }

        public ActionResult Edit(int id)
        {

            ICollection<Brand> _Brands;
            ICollection<Category> _Categories;
            ICollection<Store> _Stores;
            ICollection<Company> _Companies;


            _Categories = _categoryService.GetCategories().ToList();
            _Brands = _brandService.GetBrands().ToList();
            _Stores = _StoreService.GetStores().ToList();
            _Companies = _companyService.GetCompanies().ToList();


            var subscriberVM = new SubscriberVM
            {
                CategoriesVM = Mapper.Map<ICollection<Category>, ICollection<CategoryVM>>(_Categories),
                BrandsVM = Mapper.Map<ICollection<Brand>, ICollection<BrandVM>>(_Brands),
                StoresVM = Mapper.Map<ICollection<Store>, ICollection<StoreVM>>(_Stores),
                CompaniesVM = Mapper.Map<ICollection<Company>, ICollection<CompanyVM>>(_Companies)

            };

            var existing = _productService.GetProduct(id);
            var viewModelProduct = Mapper.Map<Product, ProductVM>(existing);
            viewModelProduct.MySubscriberVM = subscriberVM;

            return View(viewModelProduct);
        }

        public ActionResult Details(int id)
        {
            var existing = _productService.GetProduct(id);
            var viewModelProduct = Mapper.Map<Product, ProductVM>(existing);
  
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

#region
       
#endregion
    }
}