﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SNOW_Solution.Models
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}