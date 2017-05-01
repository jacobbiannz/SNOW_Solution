using Snow.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Snow.Web.ViewModels
{
    public class ReceiptVM
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        
        public String PaymentType { get; set; }

        public OrderVM orderVM { get; set; }
    }
}