using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Snow.Model
{
    public class Customer : AuditableEntity<Customer>
    {
        [Required]
        public DateTime CreateTime { get; set; }

        public Company MyCompany { get; set; }

        //public List<Order> AllOrders { get; set; }

    }
}