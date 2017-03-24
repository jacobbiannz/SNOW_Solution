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
    class PaymentTypeService : IPaymentTypeService
    {
        private readonly IPaymentTypeRepository _paymentTypeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PaymentTypeService(IPaymentTypeRepository PaymentTypeRepository, IUnitOfWork unitOfWork)
        {
            _paymentTypeRepository = PaymentTypeRepository;
            _unitOfWork = unitOfWork;
        }

        #region IPaymentTypeService Members

        public void CreatePaymentType(PaymentType paymentType)
        {
            _paymentTypeRepository.Add(paymentType);
        }
        public void UpdatePaymentType(PaymentType paymentType)
        {
            _paymentTypeRepository.Update(paymentType);
        }
        public void DeletePaymentType(PaymentType paymentType)
        {
            _paymentTypeRepository.Delete(paymentType);
        }

        public PaymentType GetPaymentType(string name)
        {
            var paymentType = _paymentTypeRepository.GetPaymentTypeByName(name);
            return paymentType;
        }

        public PaymentType GetPaymentType(int id)
        {
            var PaymentType = _paymentTypeRepository.GetById(id);
            return PaymentType;
        }

        public IEnumerable<PaymentType> GetPaymentTypes(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return _paymentTypeRepository.GetAll();
            return _paymentTypeRepository.GetAll().Where(c => c.Name == name);

        }
        public void SavePaymentType()
        {
            _unitOfWork.Commit();
        }

        public Task<int> SavePaymentTypeAsync()
        {
            return _unitOfWork.CommitAsync();
        }
        #endregion
    }
}
