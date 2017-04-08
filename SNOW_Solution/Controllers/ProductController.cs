using AutoMapper;
using Snow.Service;
using Snow.Model;
using Snow.Web.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Snow.Web.ViewModels;
using Snow.Model.Models;
using System;
using System.Threading.Tasks;
using System.Net;
using Snow.Service.Interface;

namespace Snow.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IImageInfoService _imageInfoService;
        private readonly IImageService _imageService;
        private readonly ICategoryService _categoryService;
        private readonly IBrandService _brandService;
        private readonly ICompanyService _companyService;
        
        public ProductController(IProductService productService, 
                                   IImageService imageService,
                                   IImageInfoService imageInfoService,
                                   ICategoryService categoryService,
                                   ICompanyService companyService,
                                   IBrandService brandService
                                   )
        {
            _productService = productService;
            _imageService = imageService;
            _imageInfoService = imageInfoService;
            _categoryService = categoryService;
            _companyService = companyService;
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
            ICollection<Company> _Companies;


            _Categories = _categoryService.GetCategories().ToList();
            _Brands = _brandService.GetBrands().ToList();
            _Companies = _companyService.GetCompanies().ToList();

           
            var subscriberVM = new SubscriberVM
            {
                CategoriesVM = Mapper.Map<ICollection<Category>, ICollection<CategoryVM>>(_Categories),
                BrandsVM = Mapper.Map<ICollection<Brand>, ICollection<BrandVM>>(_Brands),
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
        public async Task<ActionResult> Create(ProductVM productVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (productVM != null && productVM.Photos != null)
                    {
                        var prod = Mapper.Map<ProductVM, Product>(productVM);
                        prod.BrandId = productVM.BrandId;
                        prod.CategoryId = productVM.CategoryId;
                        prod.CompanyId = productVM.CompanyId;
                        _productService.CreateProduct(prod);

                        foreach (var info in productVM.ImagesDict)
                        {

                            var imageInfoVM = new ImageInfoVM()
                            {
                                Photo = info.Value,
                                Name = info.Key.Name,
                                ContentType = info.Key.ContentType,
                                IsMain = info.Key.IsMain,
                                IsSelected = info.Key.IsSelected
                            };

                            var imageInfo = Mapper.Map<ImageInfoVM, ImageInfo>(imageInfoVM);

                            _imageInfoService.CreateImageInfo(imageInfo);

                            var imageVM = new ImageVM
                            {
                                Photo = info.Value
                            };
                            var image = Mapper.Map<ImageVM, Image>(imageVM);

                            _imageService.CreateImage(image);
                            await _imageService.SaveImageAsync();
                            await _imageInfoService.SaveImageInfoAsync();
                        }
                       
                        await _productService.SaveProductAsync();
                    }
                }
                catch (Exception e)
                {
                    return RedirectToAction("General/Error");
                }

                
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit(ProductVM productVM)
        {
            if (ModelState.IsValid)
            {
                var product = _productService.GetProduct(productVM.ProductId);
                var prodVM = Mapper.Map<Product,ProductVM>(product);

                if (prodVM != null)
                {
                   
                    product.Name = productVM.Name;
                    product.Description = productVM.Description;
                    product.StockPrice = productVM.StockPrice;
                    product.MarketPrice = productVM.MarketPrice;
                    product.CategoryId = productVM.CategoryId;
                    product.BrandId = productVM.BrandId;

                    try
                    {
                        foreach (var info in productVM.ImagesDict)
                        {
                            var imageInfoVM = new ImageInfoVM()
                            {
                                Photo = info.Value,
                                Name = info.Key.Name,
                                ContentType = info.Key.ContentType,
                                IsMain = info.Key.IsMain,
                                IsSelected = info.Key.IsSelected,
                                ProductId = product.Id
                            };

                            var imageInfo = Mapper.Map<ImageInfoVM, ImageInfo>(imageInfoVM);

                            _imageInfoService.CreateImageInfo(imageInfo);

                            var imageVM = new ImageVM
                            {
                                Photo = info.Value
                            };
                            var image = Mapper.Map<ImageVM, Image>(imageVM);


                            _imageService.CreateImage(image);
                            await _imageService.SaveImageAsync();
                            await _imageInfoService.SaveImageInfoAsync();
                        }
                        _productService.UpdateProduct(product);
                        await _productService.SaveProductAsync();
                    }
                    catch(Exception e)
                    {
                        return RedirectToAction("General/Error");
                    }
                }
            }
            return RedirectToAction("Index");
        }



        public ActionResult Delete(int id)
        {

            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product =  _productService.GetProduct(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            var viewModelProduct = Mapper.Map<Product, ProductVM>(product);
            return View(viewModelProduct);
        }
        // POST: /Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var product = _productService.GetProduct(id);
                    product.IsDeleted = true;

                    _productService.UpdateProduct(product);
                    await _productService.SaveProductAsync();
                }
                catch (Exception e)
                {
                    return RedirectToAction("General/Error");
                }
                return RedirectToAction("Index");
            }
            return View();
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
            ICollection<Company> _Companies;


            _Categories = _categoryService.GetCategories().ToList();
            _Brands = _brandService.GetBrands().ToList();
            _Companies = _companyService.GetCompanies().ToList();


            var subscriberVM = new SubscriberVM
            {
                CategoriesVM = Mapper.Map<ICollection<Category>, ICollection<CategoryVM>>(_Categories),
                BrandsVM = Mapper.Map<ICollection<Brand>, ICollection<BrandVM>>(_Brands),
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