using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snow.Model
{
    public class Store : AuditableEntity<Store>
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        [ForeignKey("MyCompany")]
        public int CompanyId { get; set; }
        public virtual Company MyCompany { get; set; }    
        public virtual ICollection<Product> AllProducts { get; set; }
        public virtual ICollection<Inventory> AllInventories { get; set; }

    }
}