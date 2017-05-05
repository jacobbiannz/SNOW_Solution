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

        public Inventory GetInventoryByBarcode(int barcode)
        {
            var Inventory = DbContext.Inventories.Where(c => c.Barcode == barcode).FirstOrDefault();

            return Inventory;
        }


        public Inventory GetInventoryBySPS(Store store, Product product, Size size)
        {
            Inventory inventory = DbContext.Inventories.Where(c => (c.MyStore.Id == store.Id)
                                                            && (c.MyProduct.Id == product.Id)
                                                            && (c.MySize.Id == size.Id)).FirstOrDefault();

            return inventory;
        }

        public override void Update(Inventory entity)
        {
            entity.UpdatedDate = DateTime.Now;
            base.Update(entity);
        }
    }
}
