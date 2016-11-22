using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SNOW_Solution.Models
{
    public class Address : AuditableEntity<Address>
    {
        [Required]
        [MaxLength(50)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }
        
        [MaxLength(100)]
        public string AddressLine1 { get; set; }

        [MaxLength(100)]
        public string AddressLine2 { get; set; }

        [Range(0,15)]
        public int PostCode { get; set; }

        [ForeignKey("MyCity")]
        public int CityId { get; set; }
        public City MyCity { get; set; }
    }
}
