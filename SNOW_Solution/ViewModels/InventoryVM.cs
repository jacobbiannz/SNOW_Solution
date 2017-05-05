using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Snow.Web.ViewModel
{
    public class InventoryVM
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int Barcode { get; set; }
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int SizeId { get; set; }
        public string SizeName { get; set; }
        public SubscriberVM MySubscriberVM { get; set; }
    }
}