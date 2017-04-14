using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snow.Model
{
    public class Order : AuditableEntity<Order>
    {
        
        //myCustomer(bo)
        [Required]
        [ForeignKey("MyStore")]
        public int StoreId { get; set; }
        public virtual Store MyStore { get; set; }

        [Required]
        [ForeignKey("MyOrderStatus")]
        public int OrderStatusId { get; set; }
        public virtual OrderStatus MyOrderStatus { get; set; }

        public virtual ICollection<Receipt> AllReceipts { get; set; }
        public virtual ICollection<OrderDetail> AllOrderDetails { get; set; }
        public virtual ICollection<Promotion> AllPromotions { get; set; }
    }
}