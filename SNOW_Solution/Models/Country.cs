using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SNOW_Solution.Models
{
    public class Country : AuditableEntity<Country>
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public decimal Tax { get; set; }

        public virtual ICollection<RegionState> AllRegionSatates { get; set; }


        public virtual ICollection<City> AllCities { get; set; }


        public string Code { get; set; }
    }
}