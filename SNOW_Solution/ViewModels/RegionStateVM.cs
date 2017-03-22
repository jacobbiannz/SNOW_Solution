using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Snow.Model;
using System.Web.Mvc;

namespace Snow.Web.ViewModel
{
    public class RegionStateVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public SubscriberVM MySubscriberVM { get; set;}
    }
}