using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snow.Model
{
    public class Category : AuditableEntity<Category>
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [ForeignKey("MyCompany")]
        public int CompanyId { get; set; }
        public virtual Company MyCompany { get; set; }
        public ICollection<Product> AllProducts { get; set; }
    }
}