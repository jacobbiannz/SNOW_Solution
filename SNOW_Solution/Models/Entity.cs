using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SNOW_Solution.Models
{
    public abstract class BaseEntity
    {

    }
    public abstract class Entity<T> : BaseEntity, IEntity<T>
    {
        public virtual T Id { get; set; }
    }
}