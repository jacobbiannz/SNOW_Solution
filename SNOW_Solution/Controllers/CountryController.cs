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
    public class CountryController : Controller
    {
        private readonly ICountryRepository countryRepository;

        public CountryController(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }

        public void CountryUpdate(CountryVM countryVM, Country country)
        {
            country.Name = countryVM.Name;
            country.Code = countryVM.Code;
            country.Tax = countryVM.Tax;
        }

        private CountryVM countryVMFromExist(Country country)
        {
            CountryVM countryVM = new CountryVM
            {
                Id = country.Id,
                Name = country.Name,
                Code = country.Code,
                Tax = country.Tax
            };
            return countryVM;
        }
        //-------------------------------------------------
        public ActionResult Index()
        {
            var model = (List<Country>)countryRepository.SelectAll();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var country = (Country)countryRepository.SelectByID(id);
            return View(country);
        }

        public ActionResult create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CountryVM countryVM)
        {
            if (ModelState.IsValid)
            {
                Country country = new Country();
                CountryUpdate(countryVM, country);
                countryRepository.Insert(country);
                countryRepository.Save();
                return RedirectToAction("Index");
            }
            return View(countryVM);
        }



        public ActionResult Edit(int id)
        {
            var country = (Country)countryRepository.SelectByID(id);
            if (country == null) return new HttpNotFoundResult();
            CountryVM countryVM = countryVMFromExist(country);
            return View(countryVM);
        }

        [HttpPost]
        public ActionResult Edit(CountryVM countryVM)
        {
            if (ModelState.IsValid)
            {
                var country = (Country)countryRepository.SelectByID(countryVM.Id);
                CountryUpdate(countryVM, country);
                countryRepository.Update(country);
                countryRepository.Save();
                return RedirectToAction("Index");
            }
            return View(countryVM);
        }

        public ActionResult Delete(int id)
        {
            var country = (Country)countryRepository.SelectByID(id);
            return View(country);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var country = (Country)countryRepository.SelectByID(id);
            countryRepository.Delete(id);
            countryRepository.Save();
            return RedirectToAction("Index");
        }
    }
}