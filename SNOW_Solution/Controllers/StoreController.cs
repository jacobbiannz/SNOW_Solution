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
    public class StoreController : Controller
    {
        private readonly IStoreService _StoreService;
        private readonly ICompanyService _CompanyService;

        public StoreController(IStoreService StoreService,
                                     ICompanyService CompanyService)
        {
            _StoreService = StoreService;
            _CompanyService = CompanyService;
        }

        public ActionResult Index(StoreVM Store = null)
        {
            IEnumerable<StoreVM> viewModelStores;
            IEnumerable<Store> Stores;

            Stores = _StoreService.GetStores(Store.Name).ToList();

            viewModelStores = Mapper.Map<IEnumerable<Store>, IEnumerable<StoreVM>>(Stores);

            return View(viewModelStores);
        }

        public ActionResult Details(int id)
        {
            var existing = _StoreService.GetStore(id);
            var vmStore = Mapper.Map<Store, StoreVM>(existing);
            return View(vmStore);
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

            var StoreVM = new StoreVM();
            StoreVM.MySubscriberVM = subscriberVM;
            return View(StoreVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(StoreVM StoreVM)
        {
            if (ModelState.IsValid)
            {
                if (StoreVM != null)
                {
                    var Store = Mapper.Map<StoreVM, Store>(StoreVM);
                    _StoreService.CreateStore(Store);
                    _StoreService.SaveStore();
                }
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            ICollection<Company> _Companies;
            _Companies = _CompanyService.GetCompanies().ToList();

            var existing = _StoreService.GetStore(id);
            if (existing == null)
            {
                return HttpNotFound();
            }

            var StoreVM = Mapper.Map<Store, StoreVM>(existing);

            var subscriberVM = new SubscriberVM
            {
                CompaniesVM = Mapper.Map<ICollection<Company>, ICollection<CompanyVM>>(_Companies)
            };

            StoreVM.MySubscriberVM = subscriberVM;
            return View(StoreVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(StoreVM StoreVM)
        {
            if (ModelState.IsValid)
            {
                var existing = Mapper.Map<StoreVM, Store>(StoreVM);
                _StoreService.UpdateStore(existing);
                _StoreService.SaveStore();
                return RedirectToAction("Index");
            }
            return View(StoreVM);
        }

        

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var existing = _StoreService.GetStore(id);
            var StoreVM = Mapper.Map<Store, StoreVM>(existing);
            return View(StoreVM);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(StoreVM StoreVM)
        {
            if (ModelState.IsValid)
            {
                var existing = Mapper.Map<StoreVM, Store>(StoreVM);
                _StoreService.DeleteStore(existing);
                _StoreService.SaveStore();
                return RedirectToAction("Index");
            }
            return View(StoreVM);
        }


    }
}