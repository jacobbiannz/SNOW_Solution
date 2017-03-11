using Snow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snow.Service
{
    public interface IPaymentTypeService
    {
        IEnumerable<PaymentType> GetPaymentTypes(string name = null);
        PaymentType GetPaymentType(int id);
        PaymentType GetPaymentType(string name);
        void CreatePaymentType(PaymentType brand);
        void UpdatePaymentType(PaymentType brand);
        void DeletePaymentType(PaymentType brand);
        void SavePaymentType();

    }
}
