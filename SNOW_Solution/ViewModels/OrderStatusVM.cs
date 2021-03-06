﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Snow.Web.ViewModel
{
    public class OrderStatusVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public SubscriberVM MySubscriberVM { get; set; }
    }
}