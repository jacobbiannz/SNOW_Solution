using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SNOW_Solution.Models
{
    public class Company : AuditableEntity<Company>
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }


        [ForeignKey("MyAddress")]
        public int AddressId { get; set; }
        public Address MyAddress { get; set; }
        public virtual ICollection<Store> AllStores { get; set; }

        public virtual ICollection<Product> AllProducts { get; set; }


        public virtual ICollection<Promotion> AllPromotions { get; set; }

        [ForeignKey("AllBrands")]
        public virtual ICollection<Brand> AllBrands { get; set; }

        public virtual ICollection<Category> AllCategories{ get; set; }

        public ICollection<Promotion> AllPromotions { get; set; }


       
        public virtual ICollection<Brand> AllBrands { get; set; }

        public virtual ICollection<OrderStatus> AllOrderStatus { get; set; }

        public virtual ICollection<PaymentType> AllPaymentTypes { get; set; }

        public virtual ICollection<SizeType> AllSizeTypes { get; set; }
    }
}