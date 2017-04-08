using Snow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snow.Service
{
    public interface IOrderService
    {
        IEnumerable<Order> GetOrderes(string name = null);
        Order GetOrder(int id);
        //Order GetOrder(string name);
        void CreateOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
        void SaveOrder();
        Task<int> SaveOrderAsync();
    }
}
