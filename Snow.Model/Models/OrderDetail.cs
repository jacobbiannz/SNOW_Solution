using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SNOW_Solution.Models
{
    public class OrderDetail : AuditableEntity<OrderDetail>
    {
        [Required]
        public int Quantity { get; set; }

       
        [ForeignKey("MyOrder")]
        public int OrderId { get; set; }
        public virtual Order MyOrder { get; set; }

        [ForeignKey("MyProduct")]
        public int ProductId{ get; set; }
        public virtual Product MyProduct { get; set; }

        [ForeignKey("MySize")]
        public int SizeId { get; set; }
        public virtual Size MySize { get; set; }
    }
}