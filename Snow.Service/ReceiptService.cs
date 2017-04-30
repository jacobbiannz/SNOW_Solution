using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snow.Model;
using Snow.Data.Infrastructure;
using Snow.Data.Repository;

namespace Snow.Service
{
    public class ReceiptService : IReceiptService
    {
        private readonly IReceiptRepository receiptRepository;
        private readonly IUnitOfWork unitOfWork;

        public ReceiptService(IReceiptRepository receiptRepository, IUnitOfWork unitOfWork)
        {
            this.receiptRepository = receiptRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IReceiptService Members


        public void SaveReceipt()
        {
            unitOfWork.Commit();
        }

        public Task<int> SaveReceiptAsync()
        {
            return unitOfWork.CommitAsync();
        }

        Receipt IReceiptService.GetReceipt(int id)
        {
            var receipt = receiptRepository.GetById(id);

            return receipt;
        }

        public void CreateReceipt(Receipt receipt)
        {
            receiptRepository.Add(receipt);
        }

        public void UpdateReceipt(Receipt receipt)
        {
            receiptRepository.Update(receipt);
        }

        public Task<int> SaveReceipttAsync()
        {
            return unitOfWork.CommitAsync();
        }
        #endregion
    }
}
