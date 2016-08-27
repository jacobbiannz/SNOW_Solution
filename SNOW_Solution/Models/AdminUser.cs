using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SNOW_Solution.Models
{
    public class AdminUser : Contact
    {
        public int AdminUserId { get; set; }

        public string UserName { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime LastLogin { get; set; }

        public Company MyCompany { get; set; }

        //public Role MyRole { get; set; }

        //public Store MyStore { get; set; }
    }
}