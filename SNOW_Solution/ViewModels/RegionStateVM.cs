using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SNOW_Solution.Models;
using System.Web.Mvc;

namespace SNOW_Solution.Web.ViewModels
{
    public class RegionStateVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SelectedCountryId { get; set; }
        public IEnumerable<SelectListItem> Countries { get; set; }
    }
}