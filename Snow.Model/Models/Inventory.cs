using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snow.Model
{
    public class Inventory : AuditableEntity<Inventory>
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public int Quantity { get; set; }

        [Required]
        [ForeignKey("MyProduct")]
        public int ProductId { get; set; }
        public virtual Product MyProduct { get; set; }
        [Required]
        [ForeignKey("MySize")]
        public int SizeId { get; set; }
        public Size MySize { get; set; }
    }
}