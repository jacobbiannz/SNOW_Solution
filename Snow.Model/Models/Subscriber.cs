using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SNOW_Solution.Models
{
    public class Subscriber : AuditableEntity<Subscriber>
    {
        public ICollection<Company> AllCompanies { get; set; }
       // public ICollection<ApplicationUser> AllUsers { get; set; }
    }
}