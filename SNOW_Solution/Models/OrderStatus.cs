using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SNOW_Solution.Models
{
    public class OrderStatus
    {
        public int OrderStatusId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [ForeignKey("MyCompany")]
        public int CompanyId { get; set; }
        public Company MyCompany { get; set; }

        public ICollection<Order> AllOrders { get; set; }
    }
}