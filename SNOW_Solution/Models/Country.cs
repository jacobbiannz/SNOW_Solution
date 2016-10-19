using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SNOW_Solution.Models
{
    public class Country
    {
        public int CountryId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public decimal Tax { get; set; }

        public ICollection<Region> AllRegions { get; set; }

        public ICollection<City> AllCities { get; set; }
    }
}