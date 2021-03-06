﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Snow.Model
{
    public class OrderDetail : AuditableEntity<OrderDetail>
    {
        [Required]
        public int Quantity { get; set; }

        public decimal Price { get; set; }

        [Required]
        [ForeignKey("MyOrder")]
        public int OrderId { get; set; }
        public virtual Order MyOrder { get; set; }

        [Required]
        [ForeignKey("MyProduct")]
        public int ProductId{ get; set; }
        public virtual Product MyProduct { get; set; }

        [Required]
        [ForeignKey("MySize")]
        public int SizeId { get; set; }
        public virtual Size MySize { get; set; }
    }
}