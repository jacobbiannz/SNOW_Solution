
using SNOW_Solution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SNOW_Solution.Controllers
{
    public class AdminUserController : Controller
    {
        CompanyDbContext context = new CompanyDbContext();
            

        // GET: AdminUser
        public ActionResult Index()
        {
            return View(context.AdminUsers.ToList());
        }
    }
}