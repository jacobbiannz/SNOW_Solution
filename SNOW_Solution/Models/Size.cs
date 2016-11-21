using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SNOW_Solution.Models
{
    public class Size : AuditableEntity<Size>
    {
        public int SizeId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [ForeignKey("MySizeType")]
        public int SizeTypeId { get; set; }
        public SizeType MySizeType { get; set; }

        public ICollection<Inventory> AllInventories { get; set; }
        public ICollection<OrderDetail> AllOrderDetails { get; set; }
    }
}