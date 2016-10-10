using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SNOW_Solution.Models
{
    public class Receipt
    {
        public int ReceiptId { get; set; }

        [Required]
        [ForeignKey("MyOrder")]
        public int OrderId { get; set; }
        public Order MyOrder { get; set; }

        [Required]
        [ForeignKey("MyOrder")]
        public int PaymentTypeId { get; set; }
        public PaymentType MyPaymentType { get; set; }
    }
}