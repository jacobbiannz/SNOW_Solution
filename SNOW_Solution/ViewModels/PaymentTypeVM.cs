using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Snow.Web.ViewModel
{
    public class PaymentTypeVM
    {
        public int Id { get; set; }
        [Required]
        [Remote("IsNameUnique", "PaymentType", ErrorMessage = "This Name is already exist.")]
        public string Name { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public SubscriberVM MySubscriberVM { get; set; }
    }
}