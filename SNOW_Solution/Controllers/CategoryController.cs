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
    public class CategoryController : Controller
    {
        private readonly ICategoryService _CategoryService;
        private readonly ICompanyService _CompanyService;

        public CategoryController(ICategoryService CategoryService,
                                     ICompanyService CompanyService)
        {
            _CategoryService = CategoryService;
            _CompanyService = CompanyService;
        }

        public ActionResult Index(CategoryVM Category = null)
        {
            IEnumerable<CategoryVM> viewModelCategorys;
            IEnumerable<Category> Categorys;

            Categorys = _CategoryService.GetCategories(Category.Name).ToList();

            viewModelCategorys = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryVM>>(Categorys);

            return View(viewModelCategorys);
        }

        public ActionResult Details(int id)
        {
            var existing = _CategoryService.GetCategory(id);
            var vmCategory = Mapper.Map<Category, CategoryVM>(existing);
            return View(vmCategory);
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

            var CategoryVM = new CategoryVM();
            CategoryVM.MySubscriberVM = subscriberVM;
            return View(CategoryVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(CategoryVM CategoryVM)
        {
            if (ModelState.IsValid)
            {
                if (CategoryVM != null)
                {
                    var Category = Mapper.Map<CategoryVM, Category>(CategoryVM);
                    _CategoryService.CreateCategory(Category);
                    _CategoryService.SaveCategory();
                }
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            ICollection<Company> _Companies;
            _Companies = _CompanyService.GetCompanies().ToList();

            var existing = _CategoryService.GetCategory(id);
            if (existing == null)
            {
                return HttpNotFound();
            }

            var CategoryVM = Mapper.Map<Category, CategoryVM>(existing);

            var subscriberVM = new SubscriberVM
            {
                CompaniesVM = Mapper.Map<ICollection<Company>, ICollection<CompanyVM>>(_Companies)
            };

            CategoryVM.MySubscriberVM = subscriberVM;
            return View(CategoryVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(CategoryVM CategoryVM)
        {
            if (ModelState.IsValid)
            {
                var existing = Mapper.Map<CategoryVM, Category>(CategoryVM);
                _CategoryService.UpdateCategory(existing);
                _CategoryService.SaveCategory();
                return RedirectToAction("Index");
            }
            return View(CategoryVM);
        }

        

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var existing = _CategoryService.GetCategory(id);
            var CategoryVM = Mapper.Map<Category, CategoryVM>(existing);
            return View(CategoryVM);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(CategoryVM CategoryVM)
        {
            if (ModelState.IsValid)
            {
                var existing = Mapper.Map<CategoryVM, Category>(CategoryVM);
                _CategoryService.DeleteCategory(existing);
                _CategoryService.SaveCategory();
                return RedirectToAction("Index");
            }
            return View(CategoryVM);
        }


    }
}