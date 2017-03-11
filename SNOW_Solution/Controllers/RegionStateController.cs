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
    public class RegionStateController : Controller
    {
        private readonly IRegionStateService _RegionStateService;
        private readonly ICountryService _CountryStateService;

        public RegionStateController(IRegionStateService RegionStateService,
                                     ICountryService countryService)
        {
            _RegionStateService = RegionStateService;
            _CountryStateService = countryService;
        }

        public ActionResult Index(RegionStateVM RegionState = null)
        {
            IEnumerable<RegionStateVM> viewModelRegionStates;
            IEnumerable<RegionState> RegionStates;

            RegionStates = _RegionStateService.GetRegionStates(RegionState.Name).ToList();

            viewModelRegionStates = Mapper.Map<IEnumerable<RegionState>, IEnumerable<RegionStateVM>>(RegionStates);

            return View(viewModelRegionStates);
        }

        public ActionResult Details(int id)
        {
            var existing = _RegionStateService.GetRegionState(id);
            var vmRegionstate = Mapper.Map<RegionState, RegionStateVM>(existing);
            return View(vmRegionstate);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ICollection<Country> _Countries;
            _Countries = _CountryStateService.GetCountries().ToList();

            var subscriberVM = new SubscriberVM
            {
                CountriesVM = Mapper.Map<ICollection<Country>, ICollection<CountryVM>>(_Countries)
            };

            var regionStateVM = new RegionStateVM();
            regionStateVM.MySubscriberVM = subscriberVM;
            return View(regionStateVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(RegionStateVM RegionStateVM)
        {
            if (ModelState.IsValid)
            {
                if (RegionStateVM != null)
                {
                    var RegionState = Mapper.Map<RegionStateVM, RegionState>(RegionStateVM);
                    _RegionStateService.CreateRegionState(RegionState);
                    _RegionStateService.SaveRegionState();
                }
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            ICollection<Country> _Countries;
            _Countries = _CountryStateService.GetCountries().ToList();

            var existing = _RegionStateService.GetRegionState(id);
            if (existing == null)
            {
                return HttpNotFound();
            }

            var regionStateVM = Mapper.Map<RegionState, RegionStateVM>(existing);

            var subscriberVM = new SubscriberVM
            {
                CountriesVM = Mapper.Map<ICollection<Country>, ICollection<CountryVM>>(_Countries)
            };

            regionStateVM.MySubscriberVM = subscriberVM;
            return View(regionStateVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(RegionStateVM RegionStateVM)
        {
            if (ModelState.IsValid)
            {
                var existing = Mapper.Map<RegionStateVM, RegionState>(RegionStateVM);
                _RegionStateService.UpdateRegionState(existing);
                _RegionStateService.SaveRegionState();
                return RedirectToAction("Index");
            }
            return View(RegionStateVM);
        }

        

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var existing = _RegionStateService.GetRegionState(id);
            var RegionStateVM = Mapper.Map<RegionState, RegionStateVM>(existing);
            return View(RegionStateVM);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(RegionStateVM RegionStateVM)
        {
            if (ModelState.IsValid)
            {
                var existing = Mapper.Map<RegionStateVM, RegionState>(RegionStateVM);
                _RegionStateService.DeleteRegionState(existing);
                _RegionStateService.SaveRegionState();
                return RedirectToAction("Index");
            }
            return View(RegionStateVM);
        }


    }
}