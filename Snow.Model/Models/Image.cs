﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace SNOW_Solution.Models
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

        //urs
        //thumb_url
        [Display(Name = "Local file")]
        [NotMapped]
        public HttpPostedFileBase File
        {
            get
            {
                return null;
            }

            set
            {
                try
                {
                    var target = new MemoryStream();

                    if (value.InputStream == null)
                        return;

                    value.InputStream.CopyTo(target);
                    Photo = target.ToArray();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
}