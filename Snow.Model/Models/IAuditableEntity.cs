using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Snow.Model
{

    public interface IAuditableEntity
    {
        DateTime? CreatedDate { get; set; }

        string CreatedBy { get; set; }

        DateTime? UpdatedDate { get; set; }

        string UpdatedBy { get; set; }
    }
}