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
    public class InventoryRepository : RepositoryBase<Inventory>, IInventoryRepository
    {
        public InventoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
        
        /*
        public Inventory GetInventoryByName(string InventoryName)
        {
            var Inventory = DbContext.Inventories.Where(c => c.Name == InventoryName).FirstOrDefault();

            return Inventory;
        }*/

        public override void Update(Inventory entity)
        {
            entity.UpdatedDate = DateTime.Now;
            base.Update(entity);
        }
    }
}
