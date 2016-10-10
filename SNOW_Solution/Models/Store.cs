﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SNOW_Solution.Models
{
    public class Store
    {

        public int StoreId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }


        public Address MyAddress { get; set; }

        [Required]
        [ForeignKey("MyCompany")]
        public int CompanyId { get; set; }
        public Company MyCompany { get; set; }
     
        public ICollection<Product> AllProducts { get; set; }
        //alluser(bo)

    }
}