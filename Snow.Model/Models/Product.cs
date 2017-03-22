using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Snow.Model;
using Snow.Model.Models;

namespace Snow.Model
{
    public class Product : AuditableEntity<Product>
    {
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
        public virtual Company MyCompany { get; set; }

        [ForeignKey("MyCategory")]
        public int CategoryId { get; set; }
        public virtual Category MyCategory { get; set; }

        [ForeignKey("MyBrand")]
        public int BrandId { get; set; }

        public virtual Brand MyBrand { get; set; }

        [ForeignKey("MyStore")]
        public int StoreId { get; set; }
        public virtual Store MyStore { get; set; }

        public virtual ICollection<Inventory> AllInventories { get; set; }

        public virtual ICollection<Promotion> AllPromotions { get; set; }

        public virtual ICollection<ImageInfo> AllImageInfos { get; set; }

        public virtual ICollection<OrderDetail> AllOrderDetails { get; set; }

    }
}