using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Snow.Model;
using System.Data.Entity;
using Snow.Data.Infrastructure;

namespace Snow.Data.Repository
{
    public class RegionStateRepository : RepositoryBase<RegionState>, IRegionStateRepository
    {

        public RegionStateRepository(IDbFactory dbFactory): base(dbFactory)
        {

        }
  
        public RegionState GetRegionStateByName(string regionStateName)
        {
            var regionState = DbContext.RegionalStates.Where(c => c.Name == regionStateName).FirstOrDefault();

            return regionState;
        }

        public override void Update(RegionState entity)
        {
            entity.UpdatedDate = DateTime.Now;
            base.Update(entity);
        }

    }
}