using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SNOW_Solution.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public decimal StockPrice { get; set; }
        
        [Required]
        public decimal MarketPrice { get; set; }

        [Required]
        public Company MyCompany { get; set; }

        //public Category MyCategory { get; set; }

        //public Brand MyBrand { get; set; }

        //public Inventory MyInventory { get; set; }

        //public List<KeyWord> AllKeyWords { get; set; }

        //public List<Promotion> AllPromotions { get; set; }

        //public List<Image> AllImages { get; set; }

        //public List<Store> AllStores { get; set; }

        //public List<OrderDetail> AllOrderDetails { get; set; }

    }
}