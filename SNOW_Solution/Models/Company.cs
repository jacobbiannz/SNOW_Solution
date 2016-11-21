using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SNOW_Solution.Models
{
    public class Company : AuditableEntity<Company>
    {
        public int CompanyId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        //alluser(bo)
        //allrole(bo)
        //allCustomer(bo)
        //allPermission(bo)
        public Address MyAddress { get; set; }

        public ICollection<Store> AllStores { get; set; }

        public ICollection<Product> AllProducts { get; set; }

        public ICollection<Promotion> AllPromotions { get; set; }

        public ICollection<Brand> AllBrands { get; set; }

        public ICollection<Category> AllCategories{ get; set; }

        public ICollection<OrderStatus> AllOrderStatus { get; set; }

        public ICollection<PaymentType> AllPaymentTypes { get; set; }

        public ICollection<SizeType> AllSizeTypes { get; set; }
    }
}