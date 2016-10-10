using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SNOW_Solution.Models
{
    public class Inventory
    {
        public int InventoryId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [ForeignKey("MyProduct")]
        public int ProductId { get; set; }
        public Product MyProduct { get; set; }

        [Required]
        [ForeignKey("MySize")]
        public int SizeId { get; set; }
        public Size MySize { get; set; }
    }
}