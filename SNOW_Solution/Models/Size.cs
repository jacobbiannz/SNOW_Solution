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
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [ForeignKey("MySizeType")]
        public int SizeTypeId { get; set; }
        public SizeType MySizeType { get; set; }

        public virtual ICollection<Inventory> AllInventories { get; set; }
        public virtual ICollection<OrderDetail> AllOrderDetails { get; set; }
    }
}