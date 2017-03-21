using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Snow.Model;

namespace Snow.Web.ViewModel
{
    public class CountryVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal Tax { get; set; }

        public SubscriberVM MySubscriberVM { set; get; }
    }
}