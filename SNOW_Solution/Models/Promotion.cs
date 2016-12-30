using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SNOW_Solution.Models
{
    public class Promotion : AuditableEntity<Promotion>
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public decimal Rate { get; set; }

        [Required]
        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        [ForeignKey("MyCompany")]
        public int? CompanyId { get; set; }
        public Company MyCompany { get; set; }

        public virtual ICollection<Product> AllProducts { get; set; }

        public virtual ICollection<Order> AllOrders { get; set; }
    }
}