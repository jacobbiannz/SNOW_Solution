using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SNOW_Solution.Models;

namespace SNOW_Solution.Models
{
    public class Product : AuditableEntity<Product>
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

        public int ClickCount { get; set; }

        [ForeignKey("MyCompany")]
        public int CompanyId { get; set; }
        public Company MyCompany { get; set; }

        [ForeignKey("MyCategory")]
        public int CategoryId { get; set; }
        public Category MyCategory { get; set; }

        [ForeignKey("MyBrand")]
        public int BrandId { get; set; }
        public Brand MyBrand { get; set; }

        [ForeignKey("MyStore")]
        public int StoreId { get; set; }
        public Store MyStore { get; set; }

        public ICollection<Inventory> AllInventories { get; set; }

        public ICollection<Promotion> AllPromotions { get; set; }

        public ICollection<Image> AllImages { get; set; }

        public ICollection<OrderDetail> AllOrderDetails { get; set; }

    }
}