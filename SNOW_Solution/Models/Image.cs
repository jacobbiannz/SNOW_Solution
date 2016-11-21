using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SNOW_Solution.Models
{
    public class Image : AuditableEntity<Image>
    {
        public int ImageId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "Image")]
        public byte[] Photo { get; set; }

        public bool IsMain { get; set; }

        [Required]
        [ForeignKey("MyProduct")]
        public int ProductId { get; set; }
        public Product MyProduct { get; set; }

        //urs
        //thumb_url
    }
}