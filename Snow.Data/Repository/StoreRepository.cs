using Snow.Data.Infrastructure;
//using Snow.Data.Repository.Interface;
using Snow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snow.Data.Repository
{
    public class StoreRepository : RepositoryBase<Store>, IStoreRepository
    {

        public StoreRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
        public Store GetStoreByName(string storeName)
        {
            var Store = DbContext.Stores.Where(c => c.Name == storeName).FirstOrDefault();

            return Store;
        }

        public override void Update(Store entity)
        {
            entity.UpdatedDate = DateTime.Now;
            base.Update(entity);
        }
    }
}
