using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Snow.Web.ViewModels
{
    public class ImageVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
        public bool IsSelected { get; set; }
        public bool IsMain { get; set; }
    }
}