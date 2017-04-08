using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Snow.Web.ViewModel
{
    public class OrderVM
    {
        public int Id { get; set; }

        public int StoreId { get; set; }
        public string StoreName { get; set; }

        public int OrderStatusId { get; set; }
        public string OrderStatusName { get; set; }

        public ICollection<OrderDetailVM> AllOrderDetailsVM { get; set; }
        public SubscriberVM MySubscriberVM { get; set; }
    }
}