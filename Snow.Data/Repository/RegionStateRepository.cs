using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Snow.Model;
using Snow.Data.Infrastructure;

namespace Snow.Data.Repository
{

    public class RegionStateRepository : RepositoryBase<RegionState>, IRegionStateRepository
    {

        public RegionStateRepository(IDbFactory dbFactory)
         : base(dbFactory)
        {

        }

    }
}