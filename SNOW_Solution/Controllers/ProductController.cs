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
            var model = (List<Product>)repository.GetAll();
            return View(model);
        }

        public ActionResult New()
        {
            return View();
        }

        public ActionResult Insert(Product obj)
        {
            repository.Add(obj);
            return View();
        }

        public ActionResult Edit(int id)
        {
            var existing = repository.GetById(id);
            return View(existing);
        }

        public ActionResult Update(Product obj)
        {
            repository.Update(obj);
            
            return View();
        }

        public ActionResult ConfirmDelete(int id)
        {
            var existing = repository.GetById(id);
            return View(existing);
        }

        public ActionResult Delete(int id)
        {
            var product = repository.GetById(id);
            repository.Delete(product);
          
            return View();
        }

    }
}