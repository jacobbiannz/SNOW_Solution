using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Snow.Model
{
    public interface IEntity<T>
    {
       int Id { get; set; }
    }
}