using Snow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snow.Service
{
    public interface IOrderStatusService
    {
        IEnumerable<OrderStatus> GetOrderStatuses(string name = null);
        OrderStatus GetOrderStatus(int id);
        OrderStatus GetOrderStatus(string name);
        void CreateOrderStatus(OrderStatus brand);
        void UpdateOrderStatus(OrderStatus brand);
        void DeleteOrderStatus(OrderStatus brand);
        void SaveOrderStatus();
        Task<int> SaveOrderStatusAsync();
    }
}
