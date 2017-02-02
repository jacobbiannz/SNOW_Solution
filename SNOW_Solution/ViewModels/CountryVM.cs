using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SNOW_Solution.Models;

namespace SNOW_Solution.ViewModels
{
    public class CountryVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal Tax { get; set; }
    }
}