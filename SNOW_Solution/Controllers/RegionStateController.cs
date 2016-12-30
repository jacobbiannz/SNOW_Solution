using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SNOW_Solution.Models;
using SNOW_Solution.ViewModels;
using SNOW_Solution.Repository;

namespace SNOW_Solution.Controllers
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
            var model = (List<RegionState>)regionStateRepository.SelectAll();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var regionState = (RegionState)regionStateRepository.SelectByID(id);
            return View(regionState);
        }

        public ActionResult create()
        {
            var regionstateVM = new RegionStateVM();
            regionstateVM.Countries = new SelectList((List<Country>)countryRepository.SelectAll(), "Id", "Name", regionstateVM.SelectedCountryId);
            return View(regionstateVM);

        }

        [HttpPost]
        public ActionResult Create(RegionStateVM regionStateVM)
        {
            if (ModelState.IsValid)
            {
                RegionState regionState = new RegionState();
                RegionStateUpdate(regionStateVM, regionState);
                regionStateRepository.Insert(regionState);
                regionStateRepository.Save();
                return RedirectToAction("Index");
            }

            regionStateVM.Countries = new SelectList((List<Country>)countryRepository.SelectAll(), "Id", "Name", regionStateVM.SelectedCountryId);

            return View(regionStateVM);
        }


        public ActionResult Edit(int id)
        {
            var regionState = (RegionState)regionStateRepository.SelectByID(id);
            return View(regionState);
        }

        [HttpPost]
        public ActionResult Edit(RegionState regionState)
        {
            if (ModelState.IsValid)
            {
                regionStateRepository.Update(regionState);
                regionStateRepository.Save();
                return RedirectToAction("Index");
            }
            return View(regionState);
        }

        public ActionResult Delete(int id)
        {
            var regionState = (RegionState)regionStateRepository.SelectByID(id);
            return View(regionState);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var regionState = (RegionState)regionStateRepository.SelectByID(id);
            regionStateRepository.Delete(id);
            regionStateRepository.Save();
            return RedirectToAction("Index");
        }
    }
}