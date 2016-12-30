using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SNOW_Solution.Models;

namespace SNOW_Solution.Repository
{

    public class RegionStateRepository : GenericRepository<RegionState>, IRegionStateRepository
    {

        public RegionStateRepository()
         : base()
        {

        }

        public RegionStateRepository(CompanyDbContext db)
           : base(db)
        {

        }
    }
}