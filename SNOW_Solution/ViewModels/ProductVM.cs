﻿using SNOW_Solution.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SNOW_Solution.ViewModels
{
    public class ProductVM
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public int CategoryID { get; set; }

        public string CategoryDescription { get; set; }

        public List<byte[]> Photos { get; set; }

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
                    if (Photos ==null)
                    {
                        Photos = new List<byte[]>();
                    }
                    
                    Photos.Add( target.ToArray());
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
}