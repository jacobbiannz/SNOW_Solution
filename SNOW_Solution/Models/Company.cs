using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SNOW_Solution.Models
{
    public class Company : Contact
    {
        public int CompanyId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        //public List<Store> AllStores { get; set; }

        //public List<Role> AllRoles { get; set; }

        //public List<Permission> AllPermissions { get; set; }

        public List<ApplicationUser> AllUsers { get; set; }

        public List<Product> AllProducts { get; set; }

        public List<Customer> AllCustomers { get; set; }

        //public List<KeyWord> AllKeyWords { get; set; }

       // public List<Promotion> AllPromotions { get; set; }

        //public List<Brand> AllBrands { get; set; }

        //public List<Category> AllCategories{ get; set; }

        //public List<OrderStatus> AllOrderStatus { get; set; }

        //public List<PaymentType> AllPaymentTypes { get; set; }

        //public List<SizeType> AllSizeTypes { get; set; }
    }
}