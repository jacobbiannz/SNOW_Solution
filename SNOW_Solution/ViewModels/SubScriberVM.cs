using SNOW_Solution.Models;
using SNOW_Solution.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SNOW_Solution.Web.ViewModels
{
    public class SubScriberVM
    {
      public ICollection<ProductVM> Products { set; get; }
      public IEnumerable<CategoryVM> Categories { set; get; }
      public ICollection<CompanyVM> Companies { set; get; }
      public ICollection<StoreVM> Stores { set; get; }
      public ICollection<BrandVM> Brands { set; get; }
    }
}