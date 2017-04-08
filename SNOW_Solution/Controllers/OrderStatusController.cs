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
    public class OrderStatusController : Controller
    {
        private readonly IOrderStatusService _OrderStatusService;
        private readonly ICompanyService _CompanyService;

        public OrderStatusController(IOrderStatusService OrderStatusService,
                                     ICompanyService CompanyService)
        {
            _OrderStatusService = OrderStatusService;
            _CompanyService = CompanyService;
        }

        public ActionResult Index(OrderStatusVM OrderStatus = null)
        {
            IEnumerable<OrderStatusVM> viewModelOrderStatuss;
            IEnumerable<OrderStatus> OrderStatuss;

            OrderStatuss = _OrderStatusService.GetOrderStatuses(OrderStatus.Name).ToList();

            viewModelOrderStatuss = Mapper.Map<IEnumerable<OrderStatus>, IEnumerable<OrderStatusVM>>(OrderStatuss);

            return View(viewModelOrderStatuss);
        }

        public ActionResult Details(int id)
        {
            var existing = _OrderStatusService.GetOrderStatus(id);
            var vmOrderStatus = Mapper.Map<OrderStatus, OrderStatusVM>(existing);
            return View(vmOrderStatus);
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

            var OrderStatusVM = new OrderStatusVM();
            OrderStatusVM.MySubscriberVM = subscriberVM;
            return View(OrderStatusVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(OrderStatusVM OrderStatusVM)
        {
            if (ModelState.IsValid)
            {
                if (OrderStatusVM != null)
                {
                    var OrderStatus = Mapper.Map<OrderStatusVM, OrderStatus>(OrderStatusVM);
                    _OrderStatusService.CreateOrderStatus(OrderStatus);
                    _OrderStatusService.SaveOrderStatus();
                }
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            ICollection<Company> _Companies;
            _Companies = _CompanyService.GetCompanies().ToList();

            var existing = _OrderStatusService.GetOrderStatus(id);
            if (existing == null)
            {
                return HttpNotFound();
            }

            var OrderStatusVM = Mapper.Map<OrderStatus, OrderStatusVM>(existing);

            var subscriberVM = new SubscriberVM
            {
                CompaniesVM = Mapper.Map<ICollection<Company>, ICollection<CompanyVM>>(_Companies)
            };

            OrderStatusVM.MySubscriberVM = subscriberVM;
            return View(OrderStatusVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(OrderStatusVM OrderStatusVM)
        {
            if (ModelState.IsValid)
            {
                var existing = Mapper.Map<OrderStatusVM, OrderStatus>(OrderStatusVM);
                _OrderStatusService.UpdateOrderStatus(existing);
                _OrderStatusService.SaveOrderStatus();
                return RedirectToAction("Index");
            }
            return View(OrderStatusVM);
        }

        

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var existing = _OrderStatusService.GetOrderStatus(id);
            var OrderStatusVM = Mapper.Map<OrderStatus, OrderStatusVM>(existing);
            return View(OrderStatusVM);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(OrderStatusVM OrderStatusVM)
        {
            if (ModelState.IsValid)
            {
                var existing = Mapper.Map<OrderStatusVM, OrderStatus>(OrderStatusVM);
                _OrderStatusService.DeleteOrderStatus(existing);
                _OrderStatusService.SaveOrderStatus();
                return RedirectToAction("Index");
            }
            return View(OrderStatusVM);
        }


    }
}