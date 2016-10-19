using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SNOW_Solution.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [ForeignKey("MyOrder")]
        public int OrderId { get; set; }
        public Order MyOrder { get; set; }


        [Required]
        [ForeignKey("MyProduct")]
        public int ProductId{ get; set; }
        public Product MyProduct { get; set; }

        [Required]
        [ForeignKey("MySize")]
        public int SizeId { get; set; }
        public Product MySize { get; set; }
    }
}