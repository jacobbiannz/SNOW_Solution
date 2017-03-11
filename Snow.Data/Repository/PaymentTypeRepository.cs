using Snow.Data.Infrastructure;
////using Snow.Data.Repository.Interface;
using Snow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snow.Data.Repository
{
    public class PaymentTypeRepository : RepositoryBase<PaymentType>, IPaymentTypeRepository
    {
        public PaymentTypeRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public PaymentType GetPaymentTypeByName(string PaymentTypeName)
        {
            var PaymentType = DbContext.PaymentTypes.Where(c => c.Name == PaymentTypeName).FirstOrDefault();

            return PaymentType;
        }

        public override void Update(PaymentType entity)
        {
            entity.UpdatedDate = DateTime.Now;
            base.Update(entity);
        }
    }
}
