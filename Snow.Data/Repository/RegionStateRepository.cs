using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SNOW_Solution.Models;
using Snow.Data.Infrastructure;

namespace SNOW_Solution.Repository
{

    public class RegionStateRepository : RepositoryBase<RegionState>, IRegionStateRepository
    {

        public RegionStateRepository(IDbFactory dbFactory)
         : base(dbFactory)
        {

        }

    }
}