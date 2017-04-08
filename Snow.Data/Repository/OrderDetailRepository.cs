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
    public class OrderDetailRepository : RepositoryBase<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
        /*
        public OrderDetail GetOrderDetailByName(string OrderDetailName)
        {
            var OrderDetail = DbContext.Orderstatuses.Where(c => c.Name == OrderDetailName).FirstOrDefault();

            return OrderDetail;
        }
        */
        public override void Update(OrderDetail entity)
        {
            entity.UpdatedDate = DateTime.Now;
            base.Update(entity);
        }
    }
}
