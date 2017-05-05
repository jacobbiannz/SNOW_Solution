using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snow.Model
{
    public class UniqueIdentifer : AuditableEntity<UniqueIdentifer>
    {
        public int productBarcode { set; get; }

        //[ForeignKey("MyCompany")]
        public int CompanyId { get; set; }
        public virtual Company MyCompany { get; set; }
    }
}
