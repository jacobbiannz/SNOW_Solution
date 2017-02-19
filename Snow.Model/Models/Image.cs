﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace Snow.Model
{
    public class Image : AuditableEntity<Image>
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "Image")]
        public byte[] Photo { get; set; }

        public bool IsMain { get; set; }

        [Required]
        [ForeignKey("MyProduct")]
        public int ProductId { get; set; }
        public virtual Product MyProduct { get; set; }
    }
}