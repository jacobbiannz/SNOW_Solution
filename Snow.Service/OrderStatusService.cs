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
    class OrderStatusService : IOrderStatusService
    {
        private readonly IOrderStatusRepository _orderStatusRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderStatusService(IOrderStatusRepository OrderStatusRepository, IUnitOfWork unitOfWork)
        {
            _orderStatusRepository = OrderStatusRepository;
            _unitOfWork = unitOfWork;
        }

        #region IOrderStatusService Members

        public void CreateOrderStatus(OrderStatus orderStatus)
        {
            _orderStatusRepository.Add(orderStatus);
        }
        public void UpdateOrderStatus(OrderStatus orderStatus)
        {
            _orderStatusRepository.Update(orderStatus);
        }
        public void DeleteOrderStatus(OrderStatus orderStatus)
        {
            _orderStatusRepository.Delete(orderStatus);
        }

        public OrderStatus GetOrderStatus(string name)
        {
            var orderStatus = _orderStatusRepository.GetOrderStatusByName(name);
            return orderStatus;
        }

        public OrderStatus GetOrderStatus(int id)
        {
            var OrderStatus = _orderStatusRepository.GetById(id);
            return OrderStatus;
        }

        public IEnumerable<OrderStatus> GetOrderStatuses(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return _orderStatusRepository.GetAll();
            return _orderStatusRepository.GetAll().Where(c => c.Name == name);

        }
        public void SaveOrderStatus()
        {
            _unitOfWork.Commit();
        }

        public Task<int> SaveOrderStatusAsync()
        {
           return  _unitOfWork.CommitAsync();
        }
        #endregion
    }
}
