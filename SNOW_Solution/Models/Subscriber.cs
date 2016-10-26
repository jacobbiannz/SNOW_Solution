using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SNOW_Solution.Models
{
    public class Subscriber
    {
        public int id { get; set; }
        public ICollection<Company> AllCompanies { get; set; }
        public ICollection<ApplicationUser> AllUsers { get; set; }
    }
}