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
    public class PaymentTypeController : Controller
    {
        private readonly IPaymentTypeService _PaymentTypeService;
        private readonly ICompanyService _CompanyService;

        public PaymentTypeController(IPaymentTypeService PaymentTypeService,
                                     ICompanyService CompanyService)
        {
            _PaymentTypeService = PaymentTypeService;
            _CompanyService = CompanyService;
        }

        public ActionResult Index(PaymentTypeVM PaymentType = null)
        {
            IEnumerable<PaymentTypeVM> viewModelPaymentTypes;
            IEnumerable<PaymentType> PaymentTypes;

            PaymentTypes = _PaymentTypeService.GetPaymentTypes(PaymentType.Name).ToList();

            viewModelPaymentTypes = Mapper.Map<IEnumerable<PaymentType>, IEnumerable<PaymentTypeVM>>(PaymentTypes);

            return View(viewModelPaymentTypes);
        }

        public ActionResult Details(int id)
        {
            var existing = _PaymentTypeService.GetPaymentType(id);
            var vmPaymentType = Mapper.Map<PaymentType, PaymentTypeVM>(existing);
            return View(vmPaymentType);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ICollection<Company> _Companies;
            _Companies = _CompanyService.GetCompanies().ToList();

            var subscriberVM = new SubscriberVM
            {
                CompaniesVM = Mapper.Map<ICollection<Company>, ICollection<CompanyVM>>(_Companies)
            };

            var PaymentTypeVM = new PaymentTypeVM();
            PaymentTypeVM.MySubscriberVM = subscriberVM;
            return View(PaymentTypeVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(PaymentTypeVM PaymentTypeVM)
        {
            if (ModelState.IsValid)
            {
                if (PaymentTypeVM != null)
                {
                    var PaymentType = Mapper.Map<PaymentTypeVM, PaymentType>(PaymentTypeVM);
                    _PaymentTypeService.CreatePaymentType(PaymentType);
                    _PaymentTypeService.SavePaymentType();
                }
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            ICollection<Company> _Companies;
            _Companies = _CompanyService.GetCompanies().ToList();

            var existing = _PaymentTypeService.GetPaymentType(id);
            if (existing == null)
            {
                return HttpNotFound();
            }

            var PaymentTypeVM = Mapper.Map<PaymentType, PaymentTypeVM>(existing);

            var subscriberVM = new SubscriberVM
            {
                CompaniesVM = Mapper.Map<ICollection<Company>, ICollection<CompanyVM>>(_Companies)
            };

            PaymentTypeVM.MySubscriberVM = subscriberVM;
            return View(PaymentTypeVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(PaymentTypeVM PaymentTypeVM)
        {
            if (ModelState.IsValid)
            {
                var existing = Mapper.Map<PaymentTypeVM, PaymentType>(PaymentTypeVM);
                _PaymentTypeService.UpdatePaymentType(existing);
                _PaymentTypeService.SavePaymentType();
                return RedirectToAction("Index");
            }
            return View(PaymentTypeVM);
        }

        

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var existing = _PaymentTypeService.GetPaymentType(id);
            var PaymentTypeVM = Mapper.Map<PaymentType, PaymentTypeVM>(existing);
            return View(PaymentTypeVM);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(PaymentTypeVM PaymentTypeVM)
        {
            if (ModelState.IsValid)
            {
                var existing = Mapper.Map<PaymentTypeVM, PaymentType>(PaymentTypeVM);
                _PaymentTypeService.DeletePaymentType(existing);
                _PaymentTypeService.SavePaymentType();
                return RedirectToAction("Index");
            }
            return View(PaymentTypeVM);
        }

        public JsonResult IsNameUnique(PaymentTypeVM paymentTypeVM)
        {
            return IsExist(paymentTypeVM.Name)
                ? Json(true, JsonRequestBehavior.AllowGet)
                : Json(false, JsonRequestBehavior.AllowGet);
        }

        public bool IsExist(string paymentTypeName)
        {
            if (_PaymentTypeService.GetPaymentType(paymentTypeName) == null)
                return true;

            return false;//Always return false to display error message
        }

    }
}