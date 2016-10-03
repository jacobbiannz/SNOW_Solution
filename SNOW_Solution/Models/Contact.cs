using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SNOW_Solution.Models
{
    public abstract class Contact
    {
        [MaxLength(50)]
        public string NameFirst{ get; set; }

        [Required]
        [MaxLength(50)]
        public string NameLast { get; set; }

        [Required]
        [MaxLength(50)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        
        [MaxLength(100)]
        public string AddressLine1 { get; set; }

        [MaxLength(100)]
        public string AddressLine2 { get; set; }

        //public Country MyCountry { get; set; } 
         
        //public City Mycity { get; set; }
    }
}
