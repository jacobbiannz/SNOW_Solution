using Snow.Data.Infrastructure;
using Snow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snow.Data.Repository
{
   public interface IOrderRepository : IRepository<Order>
    {
        //OrderStatus GetOrderByName(string brandName);
    }
}
