using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SNOW_Solution.Models
{
    public class RegionState : AuditableEntity<RegionState>
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [ForeignKey("MyCountry")]
        public int? CountryId { get; set; }
        public Country MyCountry { get; set; }

        public virtual ICollection<City> AllCities { get; set; }
    }
}