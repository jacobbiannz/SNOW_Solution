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
        public ICollection<ProductVM> Products { set; get; }
        public IEnumerable<CategoryVM> Categories { set; get; }
        public ICollection<CompanyVM> Companies { set; get; }
        public ICollection<StoreVM> Stores { set; get; }
        public ICollection<BrandVM> Brands { set; get; }
        public ICollection<CountryVM> CountriesVM { set; get; }
    
        
    }
}