using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Snow.Web.ViewModels
{
    public class ImageVM
    {
        public int Id { get; set; }

        public byte[] Photo { get; set; }

        public ImageInfoVM MyImageInfo { get; set; }
    }
}