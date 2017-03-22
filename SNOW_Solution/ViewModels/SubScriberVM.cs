using Snow.Model;
using Snow.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Snow.Web.ViewModel
{
    public class SubscriberVM
    {
        public ICollection<ProductVM> ProductsVM { set; get; }
        public IEnumerable<CategoryVM> CategoriesVM { set; get; }
        public ICollection<CompanyVM> CompaniesVM { set; get; }
        public ICollection<StoreVM> StoresVM { set; get; }
        public ICollection<BrandVM> BrandsVM { set; get; }
        public ICollection<CountryVM> CountriesVM { set; get; }
        public ICollection<PaymentTypeVM> PaymentTypesVM { set; get; }
    
        
    }
}