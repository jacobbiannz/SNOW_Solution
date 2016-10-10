using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SNOW_Solution.Models
{
    public class Promotion
    {
        public int PromotionId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public decimal Rate { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        [Required]
        [ForeignKey("MyCompany")]
        public int CompanyId { get; set; }
        public Company MyCompany { get; set; }

        public ICollection<Product> AllProducts { get; set; }

        public ICollection<Order> AllOrder { get; set; }
    }
}