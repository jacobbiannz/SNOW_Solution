using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SNOW_Solution.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal StockPrice { get; set; }

        public decimal MarketPrice { get; set; }

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