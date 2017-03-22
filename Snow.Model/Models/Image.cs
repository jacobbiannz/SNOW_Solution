using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using Snow.Model.Models;

namespace Snow.Model
{
    public class Image : AuditableEntity<Image>
    {
        [Column(TypeName = "Image")]
        public byte[] Photo { get; set; }

        [Required]
        [ForeignKey("MyImageInfo")]
        public int ImageInfoId { get; set; }
        public virtual ImageInfo MyImageInfo { get; set; }
    }
}