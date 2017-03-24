using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Snow.Web.ViewModels
{
    public class ImageInfoVM
    {
        public string Name { get; set; }
        public string ContentType { get; set; }
        public bool IsSelected { get; set; }
        public bool IsMain { get; set; }

        public int ProductId { get; set; }
        public int ImageId { get; set; }

    }
}