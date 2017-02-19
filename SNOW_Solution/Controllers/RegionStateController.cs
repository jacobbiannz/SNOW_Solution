using System.Collections.Generic;
using System.Web.Mvc;
using Snow.Model;
using SNOW_Solution.Web.ViewModels;
using Snow.Data.Repository;

namespace Snow.Web.Controllers
{
    public class RegionStateController : Controller
    {
        private readonly IRegionStateRepository regionStateRepository;
        private readonly ICountryRepository countryRepository;
        
        public RegionStateController(IRegionStateRepository regionStateRepositor, ICountryRepository countryRepository)
        {
            this.regionStateRepository = regionStateRepositor;
            this.countryRepository = countryRepository;
        }

        //-------------------------
        public void RegionStateUpdate(RegionStateVM regionStateVM, RegionState regionState)
        {
            regionState.Name = regionStateVM.Name;
            regionState.CountryId = regionStateVM.SelectedCountryId;
        }
        //--------------------------------
        public ActionResult Index()
        {
            var model = (List<RegionState>)regionStateRepository.GetAll();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var regionState = (RegionState)regionStateRepository.GetById(id);
            return View(regionState);
        }

        public ActionResult create()
        {
            var regionstateVM = new RegionStateVM();
            regionstateVM.Countries = new SelectList((List<Country>)countryRepository.GetAll(), "Id", "Name", regionstateVM.SelectedCountryId);
            return View(regionstateVM);

        }

        [HttpPost]
        public ActionResult Create(RegionStateVM regionStateVM)
        {
            if (ModelState.IsValid)
            {
                RegionState regionState = new RegionState();
                RegionStateUpdate(regionStateVM, regionState);
                regionStateRepository.Add(regionState);
                return RedirectToAction("Index");
            }

            regionStateVM.Countries = new SelectList((List<Country>)countryRepository.GetAll(), "Id", "Name", regionStateVM.SelectedCountryId);

            return View(regionStateVM);
        }


        public ActionResult Edit(int id)
        {
            var regionState = (RegionState)regionStateRepository.GetById(id);
            return View(regionState);
        }

        [HttpPost]
        public ActionResult Edit(RegionState regionState)
        {
            if (ModelState.IsValid)
            {
                regionStateRepository.Update(regionState);
                return RedirectToAction("Index");
            }
            return View(regionState);
        }

        public ActionResult Delete(int id)
        {
            var regionState = (RegionState)regionStateRepository.GetById(id);
            return View(regionState);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var regionState = (RegionState)regionStateRepository.GetById(id);
            regionStateRepository.Delete(regionState);
            return RedirectToAction("Index");
        }
    }
}