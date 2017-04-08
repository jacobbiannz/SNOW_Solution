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
    class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderDetailService(IOrderDetailRepository OrderDetailRepository, IUnitOfWork unitOfWork)
        {
            _orderDetailRepository = OrderDetailRepository;
            _unitOfWork = unitOfWork;
        }

        #region IOrderDetailService Members

        public void CreateOrderDetail(OrderDetail orderDetail)
        {
            _orderDetailRepository.Add(orderDetail);
        }
        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            _orderDetailRepository.Update(orderDetail);
        }
        public void DeleteOrderDetail(OrderDetail orderDetail)
        {
            _orderDetailRepository.Delete(orderDetail);
        }

        public OrderDetail GetOrderDetail(int id)
        {
            var OrderDetail = _orderDetailRepository.GetById(id);
            return OrderDetail;
        }

        public IEnumerable<OrderDetail> GetOrderDetails(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return _orderDetailRepository.GetAll();
            return _orderDetailRepository.GetAll();

        }
        public void SaveOrderDetail()
        {
            _unitOfWork.Commit();
        }

        public Task<int> SaveOrderDetailAsync()
        {
           return  _unitOfWork.CommitAsync();
        }
        #endregion
    }
}
