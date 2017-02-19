using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Snow.Model
{
    public class Subscriber : AuditableEntity<Subscriber>
    {
        public ICollection<Company> AllCompanies { get; set; }
      //  public ICollection<ApplicationUser> AllUsers { get; set; }
    }
}