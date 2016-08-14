using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SNOW_Solution.Models
{
    public abstract class Contact
    {
        public string NameFirst{ get; set; }

        public string NameLast { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string Password { get; set; }

        //public Country MyCountry { get; set; }

        //public City Mycity { get; set; }
    }
}