using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snow.Model
{
    public class Size : AuditableEntity<Size>
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [ForeignKey("MyCategory")]
        public int CategoryId { get; set; }
        public virtual Category MyCategory { get; set; }

        //[ForeignKey("MySizeType")]
        //public int SizeTypeId { get; set; }
        //public SizeType MySizeType { get; set; }

        public virtual ICollection<Inventory> AllInventories { get; set; }
        public virtual ICollection<OrderDetail> AllOrderDetails { get; set; }
    }
}