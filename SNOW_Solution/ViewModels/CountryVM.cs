using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Snow.Model;

namespace SNOW_Solution.Web.ViewModels
{
    public class CountryVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal Tax { get; set; }
    }
}