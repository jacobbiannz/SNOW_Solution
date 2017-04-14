using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Snow.Web.ViewModel
{
    public class OrderDetailVM
    {

        public int Id { get; set; }

        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public int OrderId { get; set; }
      
        public int ProductId { get; set; }
        public string ProductName { get; set; }
    
        public int SizetId { get; set; }
        public string SizeName { get; set; }
        public SubscriberVM MySubscriberVM { get; set; }
    }
}