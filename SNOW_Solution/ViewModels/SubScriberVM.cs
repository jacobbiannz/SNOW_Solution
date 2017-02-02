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
      public IEnumerable<ProductVM> Products { set; get; }
      public IEnumerable<CategoryVM> Categories { set; get; }
      public IEnumerable<CompanyVM> Companies { set; get; }
      public IEnumerable<StoreVM> Stores { set; get; }
      public IEnumerable<BrandVM> Brands { set; get; }
    }
}