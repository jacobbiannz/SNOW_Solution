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
    public class CompanyController : Controller
    {
        private readonly ICompanyService _CompanyService;

        public CompanyController(ICompanyService CompanyService)
        {
            _CompanyService = CompanyService;
            _CompanyService.InitializeVlidation(new ValidationDictionary(this.ModelState));
        }

        /*
        public ActionResult Index(CompanyVM Company = null)
        {;
            IEnumerable<CompanyVM> viewModelCountries;
            IEnumerable<Company> Countries;

            Countries = _CompanyService.GetCompanies(Company.Name).ToList();

            viewModelCountries = Mapper.Map<IEnumerable<Company>, IEnumerable<CompanyVM>>(Countries);

            return View(viewModelCountries);
        }
        */
        public ActionResult Details()
        {
            Company existing = _CompanyService.GetCompanies().First();
            if (existing != null)
            {
                var companyVM = Mapper.Map<Company, CompanyVM>(existing);
                return View(companyVM);
            }
            else
            {
                return RedirectToAction("Create");
            }
        }

        // POST: Items/Create

        //[ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            if (_CompanyService.GetCompanies(null).First() != null)
                return RedirectToAction("Details");
            else
                return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(CompanyVM CompanyVM)
        {
            if (ModelState.IsValid)
            {
                if (CompanyVM != null)
                {
                    var Company = Mapper.Map<CompanyVM, Company>(CompanyVM);
                    string name = _CompanyService.CreateCompany(Company);
                    if (name == null)
                        return View();
                    else
                        _CompanyService.SaveCompany();
                }
            }
            return RedirectToAction("Details");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var existing = _CompanyService.GetCompany(id);
            var viewModelCompany = Mapper.Map<Company, CompanyVM>(existing);
            return View(viewModelCompany);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(CompanyVM CompanyVM)
        {
            if (ModelState.IsValid)
            {
                var existing = Mapper.Map<CompanyVM, Company>(CompanyVM);
                _CompanyService.UpdateCompany(existing);
                 _CompanyService.SaveCompany();
                return RedirectToAction("Details");
            }
            return View(CompanyVM);
        }

        

        /*
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var existing = _CompanyService.GetCompany(id);
            var viewModelCompany = Mapper.Map<Company, CompanyVM>(existing);
            return View(viewModelCompany);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(CompanyVM CompanyVM)
        {
            if (ModelState.IsValid)
            {
                var existing = Mapper.Map<CompanyVM, Company>(CompanyVM);
                _CompanyService.DeleteCompany(existing);
                _CompanyService.SaveCompany();
                return RedirectToAction("Index");
            }
            return View(CompanyVM);
        }
        */

    }
}