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
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public ActionResult Index(CountryVM country = null)
        {
            IEnumerable<CountryVM> viewModelCountries;
            IEnumerable<Country> Countries;

            Countries = _countryService.GetCountries(country.Name).ToList();

            viewModelCountries = Mapper.Map<IEnumerable<Country>, IEnumerable<CountryVM>>(Countries);

            return View(viewModelCountries);
        }

        // POST: Items/Create
        
        //[ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(CountryVM countryVM)
        {
            if (ModelState.IsValid)
            {
                if (countryVM != null)
                {
                    var country = Mapper.Map<CountryVM, Country>(countryVM);
                    _countryService.CreateCountry(country);
                    _countryService.SaveCountry();
                }
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var existing = _countryService.GetCountry(id);
            var viewModelCountry = Mapper.Map<Country, CountryVM>(existing);
            return View(viewModelCountry);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(CountryVM countryVM)
        {
            if (ModelState.IsValid)
            {
                var existing = Mapper.Map<CountryVM, Country>(countryVM);
                _countryService.UpdateCountry(existing);
                _countryService.SaveCountry();
                return RedirectToAction("Index");
            }
            return View(countryVM);
        }

        public ActionResult Details(int id)
        {
            var existing = _countryService.GetCountry(id);
            var viewModelProduct = Mapper.Map<Country, CountryVM>(existing);
            return View(viewModelProduct);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var existing = _countryService.GetCountry(id);
            var viewModelCountry = Mapper.Map<Country, CountryVM>(existing);
            return View(viewModelCountry);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(CountryVM countryVM)
        {
            if (ModelState.IsValid)
            {
                var existing = Mapper.Map<CountryVM, Country>(countryVM);
                _countryService.DeleteCountry(existing);
                _countryService.SaveCountry();
                return RedirectToAction("Index");
            }
            return View(countryVM);
        }


    }
}