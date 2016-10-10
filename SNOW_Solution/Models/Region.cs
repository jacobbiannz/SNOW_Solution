using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SNOW_Solution.Models
{
    public class Region
    {
        public int RegionId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [ForeignKey("MyCountry")]
        public int CountryId { get; set; }
        public Country MyCountry { get; set; }
    }
}