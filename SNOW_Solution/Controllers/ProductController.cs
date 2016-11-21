using SNOW_Solution.Models;
using SNOW_Solution.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SNOW_Solution.Controllers
{
    public class ProductController : Controller
    {
        readonly IProductRepository repository;

        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            var model = (List<Product>)repository.SelectAll();
            return View(model);
        }

        public ActionResult New()
        {
            return View();
        }

        public ActionResult Insert(Product obj)
        {
            repository.Insert(obj);
            repository.Save();
            return View();
        }

        public ActionResult Edit(string id)
        {
            var existing = repository.SelectByID(id);
            return View(existing);
        }

        public ActionResult Update(Product obj)
        {
            repository.Update(obj);
            repository.Save();
            return View();
        }

        public ActionResult ConfirmDelete(string id)
        {
            var existing = repository.SelectByID(id);
            return View(existing);
        }

        public ActionResult Delete(string id)
        {
            repository.Delete(id);
            repository.Save();
            return View();
        }

    }
}