using System.Collections.Generic;
using System.Web.Mvc;
using Snow.Model;
using Snow.Web.ViewModel;
using Snow.Data.Repository;
using Snow.Service;
using AutoMapper;
using System.Linq;
using System.Web.UI;
using System.Text;
using System;
using System.IO;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.Web;

namespace Snow.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _OrderService;
        private readonly IOrderDetailService _OrderDetailService;
        private readonly IProductService _ProductService;
        private readonly ISizeService _SizeService;
        
        //private readonly ICompanyService _CompanyService;

        public OrderController(IOrderService OrderService,
                                     IOrderDetailService OrderDetailService,
                                     IProductService ProductService,
                                     ISizeService SizeService)
        {
            _OrderService = OrderService;
            _OrderDetailService = OrderDetailService;
            _ProductService = ProductService;
            _SizeService = SizeService;
        }

        public ActionResult Index(OrderVM Order = null)
        {
            IEnumerable<OrderVM> viewModelOrders;
            IEnumerable<Order> Orders;

            Orders = _OrderService.GetOrderes().ToList();

            viewModelOrders = Mapper.Map<IEnumerable<Order>, IEnumerable<OrderVM>>(Orders);

            return View(viewModelOrders);
        }

        public ActionResult Index2(OrderDetailVM OrderDetail = null)
        {
            IEnumerable<OrderDetailVM> viewModelOrders;
            IEnumerable<OrderDetail> Orders;

            Orders = _OrderDetailService.GetOrderDetails().ToList();

            viewModelOrders = Mapper.Map<IEnumerable<OrderDetail>, IEnumerable<OrderDetailVM>>(Orders);

            return View(viewModelOrders);
        }

        public ActionResult Details(int id)
        {
            var existing = _OrderService.GetOrder(id);
            var vmOrder = Mapper.Map<Order, OrderVM>(existing);
            return View(vmOrder);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            var order = new Order();
            order.StoreId = 1;
            order.OrderStatusId = 1;
            _OrderService.CreateOrder(order);
            _OrderService.SaveOrder();

            var OrderVM = Mapper.Map<Order, OrderVM>(order);
            return View(OrderVM);
        }
      
        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(OrderVM OrderVM)
        {
            return RedirectToAction("Index");
        }
        */

        [HttpGet]
        public ActionResult AddOrderDetail(string barcode, int orderId)
        {
            var orderDetail = new OrderDetail();
            orderDetail.OrderId = orderId;
            orderDetail.Quantity = 1;
            orderDetail.ProductId = 1;
            orderDetail.MyProduct = _ProductService.GetProduct(1);
            orderDetail.SizeId = 1;
            orderDetail.MySize = _SizeService.GetSize(1);
            _OrderDetailService.CreateOrderDetail(orderDetail);
            _OrderDetailService.SaveOrderDetail();

            var orderDetailVM = Mapper.Map<OrderDetail, OrderDetailVM>(orderDetail);
            var order = _OrderService.GetOrder(orderId);

            var OrderVM = Mapper.Map<Order, OrderVM>(order);

            return PartialView("_OrderDetails", OrderVM.AllOrderDetailsVM);
        }

        [HttpGet]
        public ActionResult Reset(int orderId)
        { 
            var order = _OrderService.GetOrder(orderId);
            foreach (var orderDetail in order.AllOrderDetails.ToList())
            {
                _OrderDetailService.DeleteOrderDetail(orderDetail);
                _OrderDetailService.SaveOrderDetail();
            }
            _OrderService.SaveOrder();
            var OrderVM = Mapper.Map<Order, OrderVM>(order);
            return PartialView("_OrderDetails", OrderVM.AllOrderDetailsVM);
        }
        [HttpGet]
        public ActionResult PrintInvoice(int orderId)
        {
            var order = _OrderService.GetOrder(orderId);
            var OrderVM = Mapper.Map<Order, OrderVM>(order);
            string companyName = "ASPSnippets";
            Byte[] bytes;

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[5] {
                        new DataColumn("ProductId", typeof(string)),
                        new DataColumn("Product", typeof(string)),
                        new DataColumn("Price", typeof(int)),
                        new DataColumn("Quantity",  typeof(int)),
                        new DataColumn("Total",  typeof(int))});
            dt.Rows.Add(101, "Sun Glasses", 200, 5, 1000);
            dt.Rows.Add(102, "Jeans", 400, 2, 800);
            dt.Rows.Add(103, "Trousers", 300, 3, 900);
            dt.Rows.Add(104, "Shirts", 550, 2, 1100);
            using (var ms = new MemoryStream())
            {
                using (var doc = new Document())
                {
                    using (var writer = PdfWriter.GetInstance(doc, ms))
                    {

                        doc.Open();

                        var example_html = @"<p>This <em>is </em><span class=""headline"" style=""text-decoration: underline;"">some</span> <strong>sample <em> text</em></strong><span style=""color: red;"">!!!</span></p>";
                        var example_css = @".headline{font-size:200%}";


                        using (var msCss = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(example_css)))
                        {
                            using (var msHtml = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(example_html)))
                            {

                                //Parse the HTML
                                XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, msHtml, msCss);
                            }
                        }
                        doc.Close();
                    }
                }
                bytes = ms.ToArray();
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=Invoice_" + orderId + ".pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
                Response.OutputStream.Flush();
                Response.OutputStream.Close();
                Response.End();
            }
            

            var testFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "test.pdf");
            System.IO.File.WriteAllBytes(testFile, bytes);

            return PartialView("_OrderDetails", OrderVM.AllOrderDetailsVM);
        }
        /*
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            ICollection<Company> _Companies;
            _Companies = _CompanyService.GetCompanies().ToList();

            var existing = _OrderService.GetOrder(id);
            if (existing == null)
            {
                return HttpNotFound();
            }

            var OrderVM = Mapper.Map<Order, OrderVM>(existing);

            var subscriberVM = new SubscriberVM
            {
                CompaniesVM = Mapper.Map<ICollection<Company>, ICollection<CompanyVM>>(_Companies)
            };

            OrderVM.MySubscriberVM = subscriberVM;
            return View(OrderVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(OrderVM OrderVM)
        {
            if (ModelState.IsValid)
            {
                var existing = Mapper.Map<OrderVM, Order>(OrderVM);
                _OrderService.UpdateOrder(existing);
                _OrderService.SaveOrder();
                return RedirectToAction("Index");
            }
            return View(OrderVM);
        }

        

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var existing = _OrderService.GetOrder(id);
            var OrderVM = Mapper.Map<Order, OrderVM>(existing);
            return View(OrderVM);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(OrderVM OrderVM)
        {
            if (ModelState.IsValid)
            {
                var existing = Mapper.Map<OrderVM, Order>(OrderVM);
                _OrderService.DeleteOrder(existing);
                _OrderService.SaveOrder();
                return RedirectToAction("Index");
            }
            return View(OrderVM);
        }
        */

    }
}