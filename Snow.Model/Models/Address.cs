using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snow.Model
{
    public class Address : AuditableEntity<Address>
    {
        
        [MaxLength(100)]
        public string AddressLine1 { get; set; }

        [MaxLength(100)]
        public string AddressLine2 { get; set; }

        [Range(0,15)]
        public int PostCode { get; set; }

        [ForeignKey("MyCity")]
        public int CityId { get; set; }
        public virtual City MyCity { get; set; }

        //public Store MyStore { get; set; }
    }
}
