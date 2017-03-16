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
       
        public int Quantity { get; set; }

        [Required]
        [ForeignKey("MyStore")]
        public int StoreId { get; set; }
        public virtual Store MyStore { get; set; }

        [Required]
        [ForeignKey("MyProduct")]
        public int ProductId { get; set; }
        public virtual Product MyProduct { get; set; }

        [Required]
        [ForeignKey("MySize")]
        public int SizeId { get; set; }
        public virtual Size MySize { get; set; }
    }
}