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
    public class SizeController : Controller
    {
        private readonly ISizeService _SizeService;
        private readonly ICategoryService _CategoryService;

        public SizeController(ISizeService SizeService,
                                     ICategoryService CategoryService)
        {            _SizeService = SizeService;
            _CategoryService = CategoryService;
        }

        public ActionResult Index(SizeVM Size = null)
        {
            IEnumerable<SizeVM> viewModelSizes;
            IEnumerable<Size> Sizes;

            Sizes = _SizeService.GetSizes(Size.Name).ToList();

            viewModelSizes = Mapper.Map<IEnumerable<Size>, IEnumerable<SizeVM>>(Sizes);

            return View(viewModelSizes);
        }

        public ActionResult Details(int id)
        {
            var existing = _SizeService.GetSize(id);
            var vmSize = Mapper.Map<Size, SizeVM>(existing);
            return View(vmSize);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ICollection<Category> _categories;
            _categories = _CategoryService.GetCategories().ToList();

            var subscriberVM = new SubscriberVM
            {
                CategoriesVM = Mapper.Map<ICollection<Category>, ICollection<CategoryVM>>(_categories)
            };

            var SizeVM = new SizeVM();
            SizeVM.MySubscriberVM = subscriberVM;
            return View(SizeVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(SizeVM SizeVM)
        {
            if (ModelState.IsValid)
            {
                if (SizeVM != null)
                {
                    var Size = Mapper.Map<SizeVM, Size>(SizeVM);
                    _SizeService.CreateSize(Size);
                    _SizeService.SaveSize();
                }
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            ICollection<Category> _categories;
            _categories = _CategoryService.GetCategories().ToList();

            var existing = _SizeService.GetSize(id);
            if (existing == null)
            {
                return HttpNotFound();
            }

            var SizeVM = Mapper.Map<Size, SizeVM>(existing);

            var subscriberVM = new SubscriberVM
            {
                CategoriesVM = Mapper.Map<ICollection<Category>, ICollection<CategoryVM>>(_categories)
            };

            SizeVM.MySubscriberVM = subscriberVM;
            return View(SizeVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(SizeVM SizeVM)
        {
            if (ModelState.IsValid)
            {
                var existing = Mapper.Map<SizeVM, Size>(SizeVM);
                _SizeService.UpdateSize(existing);
                _SizeService.SaveSize();
                return RedirectToAction("Index");
            }
            return View(SizeVM);
        }

        

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var existing = _SizeService.GetSize(id);
            var SizeVM = Mapper.Map<Size, SizeVM>(existing);
            return View(SizeVM);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(SizeVM SizeVM)
        {
            if (ModelState.IsValid)
            {
                var existing = Mapper.Map<SizeVM, Size>(SizeVM);
                _SizeService.DeleteSize(existing);
                _SizeService.SaveSize();
                return RedirectToAction("Index");
            }
            return View(SizeVM);
        }


    }
}