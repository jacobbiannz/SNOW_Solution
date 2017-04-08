using Snow.Data.Infrastructure;
using Snow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snow.Data.Repository
{
   public interface IOrderDetailRepository : IRepository<OrderDetail>
    {
        //OrderStatus GetOrderByName(string brandName);
    }
}
