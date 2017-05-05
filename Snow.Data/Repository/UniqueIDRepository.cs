using Snow.Data.Infrastructure;
////using Snow.Data.Repository.Interface;
using Snow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snow.Data.Repository
{
    public class UniqueIDRepository : RepositoryBase<UniqueID>, IUniqueIDRepository
    {
        public UniqueIDRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public override void Update(UniqueID entity)
        {
            entity.UpdatedDate = DateTime.Now;
            base.Update(entity);
        }
    }
}
