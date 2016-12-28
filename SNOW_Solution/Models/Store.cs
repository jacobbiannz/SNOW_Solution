using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SNOW_Solution.Models
{
    public class Store : AuditableEntity<Store>
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [ForeignKey("MyCompany")]
        public int? CompanyId { get; set; }
        public virtual Company MyCompany { get; set; }

        [ForeignKey("MyAddress")]
        public int? AddressId { get; set; }
        public virtual Address MyAddress { get; set; }
      
        public virtual ICollection<Product> AllProducts { get; set; }
        
        
        //alluser(bo)

    }
}