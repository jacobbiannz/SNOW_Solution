using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snow.Model.Models
{
    public class ImageInfo : AuditableEntity<ImageInfo>
    {
        public int ImageId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public string ContentType { get; set; }

        [Required]
        [ForeignKey("MyProduct")]
        public int ProductId { get; set; }
        public virtual Product MyProduct { get; set; }
    }
}
