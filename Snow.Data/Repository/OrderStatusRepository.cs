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
    public class OrderStatusRepository : RepositoryBase<OrderStatus>, IOrderStatusRepository
    {
        public OrderStatusRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public OrderStatus GetOrderStatusByName(string OrderStatusName)
        {
            var OrderStatus = DbContext.Orderstatuses.Where(c => c.Name == OrderStatusName).FirstOrDefault();

            return OrderStatus;
        }

        public override void Update(OrderStatus entity)
        {
            entity.UpdatedDate = DateTime.Now;
            base.Update(entity);
        }
    }
}
