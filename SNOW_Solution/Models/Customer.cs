using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SNOW_Solution.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }

        [Required]
        public DateTime CreateTime { get; set; }

        public Company MyCompany { get; set; }

        //public List<Order> AllOrders { get; set; }

    }
}