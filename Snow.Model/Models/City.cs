﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snow.Model
{
    public class City : AuditableEntity<City>
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [ForeignKey("MyRegionState")]
        public int RegionStateId { get; set; }
        public RegionState MyRegionState { get; set; }

        [ForeignKey("MyCountry")]
        public int CountryId { get; set; }
        public Country MyCountry { get; set; }
    }
}