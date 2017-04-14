using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snow.Model
{
    public class Receipt : AuditableEntity<Receipt>
    {
        [Required]
        [ForeignKey("MyOrder")]
        public int OrderId { get; set; }
        public virtual Order MyOrder { get; set; }

        [Required]
        [ForeignKey("MyPaymentType")]
        public int PaymentTypeId { get; set; }
        public virtual PaymentType MyPaymentType { get; set; }
    }
}