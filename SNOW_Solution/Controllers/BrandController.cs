using System.Collections.Generic;
using System.Web.Mvc;
using Snow.Model;
using Snow.Web.ViewModel;
using Snow.Data.Repository;
using Snow.Service;
using AutoMapper;
using System.Linq;

namespace Snow.Web.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandService _BrandService;
        private readonly ICompanyService _CompanyService;

        public BrandController(IBrandService BrandService,
                                     ICompanyService CompanyService)
        {
            _BrandService = BrandService;
            _CompanyService = CompanyService;
        }

        public ActionResult Index(BrandVM Brand = null)
        {
            IEnumerable<BrandVM> viewModelBrands;
            IEnumerable<Brand> Brands;

            Brands = _BrandService.GetBrands(Brand.Name).ToList();

            viewModelBrands = Mapper.Map<IEnumerable<Brand>, IEnumerable<BrandVM>>(Brands);

            return View(viewModelBrands);
        }

        public ActionResult Details(int id)
        {
            var existing = _BrandService.GetBrand(id);
            var vmBrand = Mapper.Map<Brand, BrandVM>(existing);
            return View(vmBrand);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ICollection<Company> _Companies;
            _Companies = _CompanyService.GetCompanies().ToList();

            var subscriberVM = new SubscriberVM
            {
                CompaniesVM = Mapper.Map<ICollection<Company>, ICollection<CompanyVM>>(_Companies)
            };

            var BrandVM = new BrandVM();
            BrandVM.MySubscriberVM = subscriberVM;
            return View(BrandVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(BrandVM BrandVM)
        {
            if (ModelState.IsValid)
            {
                if (BrandVM != null)
                {
                    var Brand = Mapper.Map<BrandVM, Brand>(BrandVM);
                    _BrandService.CreateBrand(Brand);
                    _BrandService.SaveBrand();
                }
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            ICollection<Company> _Companies;
            _Companies = _CompanyService.GetCompanies().ToList();

            var existing = _BrandService.GetBrand(id);
            if (existing == null)
            {
                return HttpNotFound();
            }

            var BrandVM = Mapper.Map<Brand, BrandVM>(existing);

            var subscriberVM = new SubscriberVM
            {
                CompaniesVM = Mapper.Map<ICollection<Company>, ICollection<CompanyVM>>(_Companies)
            };

            BrandVM.MySubscriberVM = subscriberVM;
            return View(BrandVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(BrandVM BrandVM)
        {
            if (ModelState.IsValid)
            {
                var existing = Mapper.Map<BrandVM, Brand>(BrandVM);
                _BrandService.UpdateBrand(existing);
                _BrandService.SaveBrand();
                return RedirectToAction("Index");
            }
            return View(BrandVM);
        }

        

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var existing = _BrandService.GetBrand(id);
            var BrandVM = Mapper.Map<Brand, BrandVM>(existing);
            return View(BrandVM);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(BrandVM BrandVM)
        {
            if (ModelState.IsValid)
            {
                var existing = Mapper.Map<BrandVM, Brand>(BrandVM);
                _BrandService.DeleteBrand(existing);
                _BrandService.SaveBrand();
                return RedirectToAction("Index");
            }
            return View(BrandVM);
        }


    }
}