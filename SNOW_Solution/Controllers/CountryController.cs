using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SNOW_Solution.Models;

namespace SNOW_Solution.Controllers
{
    public class CountryController : Controller
    {
        // GET: Country
        public ActionResult Index()
        {
            var countries = new List<Country>
            {
                new Country { Name = "Australia" },
                new Country { Name = "New Zealand" }
            
            };

            return View(countries);
        }
    }
}