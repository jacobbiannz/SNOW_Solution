using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SNOW_Solution.Models
{
    public class Customer : Contact
    {
        public int CustomerID { get; set; }

        public DateTime CreateTime { get; set; }

      //  public Company MyCompany { get; set; }

        //public List<Order> AllOrders { get; set; }

    }
}