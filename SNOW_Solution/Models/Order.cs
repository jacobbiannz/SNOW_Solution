using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SNOW_Solution.Models
{
    public class Order : AuditableEntity<Order>
    {
        public int OrderId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        //myCustomer(bo)

        [Required]
        [ForeignKey("MyOrderStatus")]
        public int OrderStatusId { get; set; }
        public OrderStatus MyOrderStatus { get; set; }

        public ICollection<Receipt> AllReceipts { get; set; }
        public ICollection<OrderDetail> AllOrderDetails { get; set; }
        public ICollection<Promotion> AllPromotions { get; set; }
    }
}