using AutoMapper;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using Snow.Model;
using Snow.Service;
using Snow.Web.ViewModel;
using Snow.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Snow.Web.Controllers
{
    public class ReceiptController : Controller
    {
       
        private readonly IReceiptService _receiptService;
        private readonly IOrderService _OrderService;
        private readonly IOrderDetailService _OrderDetailService;
        private readonly ICompanyService _CompanyService;
        public ReceiptController(IReceiptService receipttService,
                                   IOrderService OrderService,
                                     IOrderDetailService OrderDetailService,
                                     ICompanyService CompanyService
                                   )
        {
            _receiptService = receipttService;
            _OrderService = OrderService;
            _OrderDetailService = OrderDetailService;
            _CompanyService = CompanyService;
        }

        // GET: Receipt
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Receipt(ReceiptVM receiptVM)
        {

            var receipt = _receiptService.GetReceipt(receiptVM.Id);

            var order = _OrderService.GetOrder(receipt.OrderId);

            
            receiptVM = Mapper.Map<Receipt, ReceiptVM>(receipt);
            receiptVM.orderVM = Mapper.Map<Order, OrderVM>(order);

            return View(receiptVM);
        }

        [HttpGet]
        public ActionResult PrintInvoice(ReceiptVM receiptVM)
        {
             var order = _OrderService.GetOrder(receiptVM.OrderId);
             var OrderVM = Mapper.Map<Order, OrderVM>(order);
            string companyName = _CompanyService.GetCompanies().FirstOrDefault().Name;
            
            Byte[] bytes;

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[5] {
                        new DataColumn("ProductId", typeof(string)),
                        new DataColumn("Product", typeof(string)),
                        new DataColumn("Price", typeof(int)),
                        new DataColumn("Quantity",  typeof(int)),
                        new DataColumn("Total",  typeof(int))});

            foreach (var detail in OrderVM.AllOrderDetailsVM )
            {
                dt.Rows.Add(detail.ProductId, detail.ProductName, detail.Price, detail.Quantity, detail.Price);
            }

            using (var ms = new MemoryStream())
            {
                using (var doc = new Document())
                {
                    using (var writer = PdfWriter.GetInstance(doc, ms))
                    {

                        doc.Open();

                        var example_html = GetReceiptFormat(dt, companyName, receiptVM);
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
                var response = HttpContext.Response;
                response.ContentType = "application/pdf";
                response.AddHeader("content-disposition", "attachment;filename=Invoice.pdf");
                response.Cache.SetCacheability(HttpCacheability.NoCache);
                response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
                response.OutputStream.Flush();
                response.OutputStream.Close();
                response.End();
            }

            return View();
        }

        private string GetReceiptFormat(DataTable dt, string companyName, ReceiptVM receiptVM)
        {
            StringBuilder sb = new StringBuilder();

            //Generate Invoice (Bill) Header.
            sb.Append("<table width='100%' cellspacing='0' cellpadding='2'>");
            sb.Append("<tr><td align='center' style='background-color: #18B5F0' colspan = '2'><b>Order Sheet</b></td></tr>");
            sb.Append("<tr><td colspan = '2'></td></tr>");
            sb.Append("<tr><td><b>Order No: </b>");
            sb.Append(receiptVM.OrderId);
            sb.Append("</td><td align = 'right'><b>Date: </b>");
            sb.Append(DateTime.Now);
            sb.Append(" </td></tr>");
            sb.Append("<tr><td colspan = '2'><b>Company Name: </b>");
            sb.Append(companyName);
            sb.Append("</td></tr>");
            sb.Append("<tr><td colspan = '2'><b>Payment Type: </b>");
            sb.Append(receiptVM.PaymentType);
            sb.Append("</td></tr>");
            sb.Append("</table>");
            sb.Append("<br />");

            //Generate Invoice (Bill) Items Grid.
            sb.Append("<table border = '1'>");
            sb.Append("<tr>");
            foreach (DataColumn column in dt.Columns)
            {
                sb.Append("<th style = 'background-color: #D20B0C;color:#ffffff'>");
                sb.Append(column.ColumnName);
                sb.Append("</th>");
            }
            sb.Append("</tr>");
            foreach (DataRow row in dt.Rows)
            {
                sb.Append("<tr>");
                foreach (DataColumn column in dt.Columns)
                {
                    sb.Append("<td>");
                    sb.Append(row[column]);
                    sb.Append("</td>");
                }
                sb.Append("</tr>");
            }
            sb.Append("<tr><td align = 'right' colspan = '");
            sb.Append(dt.Columns.Count - 1);
            sb.Append("'>Total</td>");
            sb.Append("<td>");
            sb.Append(dt.Compute("sum(Total)", ""));
            sb.Append("</td>");
            sb.Append("</tr></table>");

            return sb.ToString();
        }
    }
}