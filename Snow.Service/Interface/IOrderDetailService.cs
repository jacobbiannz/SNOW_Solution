using Snow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snow.Service
{
    public interface IOrderDetailService
    {
        IEnumerable<OrderDetail> GetOrderDetails(string name = null);
        OrderDetail GetOrderDetail(int id);
        //OrderDetail GetOrderDetail(string name);
        void CreateOrderDetail(OrderDetail orderDetail);
        void UpdateOrderDetail(OrderDetail orderDetail);
        void DeleteOrderDetail(OrderDetail orderDetail);
        void SaveOrderDetail();
        Task<int> SaveOrderDetailAsync();
    }
}
