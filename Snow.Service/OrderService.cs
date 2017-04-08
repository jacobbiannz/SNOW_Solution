using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snow.Model;
using Snow.Data.Repository;
using Snow.Data.Infrastructure;

namespace Snow.Service
{
    class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IOrderRepository OrderRepository, IUnitOfWork unitOfWork)
        {
            _orderRepository = OrderRepository;
            _unitOfWork = unitOfWork;
        }

        #region IOrderService Members

        public void CreateOrder(Order order)
        {
            _orderRepository.Add(order);
        }
        public void UpdateOrder(Order order)
        {
            _orderRepository.Update(order);
        }
        public void DeleteOrder(Order order)
        {
            _orderRepository.Delete(order);
        }

        public Order GetOrder(int id)
        {
            var Order = _orderRepository.GetById(id);
            return Order;
        }

        public IEnumerable<Order> GetOrderes(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return _orderRepository.GetAll();
            return _orderRepository.GetAll();

        }
        public void SaveOrder()
        {
            _unitOfWork.Commit();
        }

        public Task<int> SaveOrderAsync()
        {
           return  _unitOfWork.CommitAsync();
        }
        #endregion
    }
}
