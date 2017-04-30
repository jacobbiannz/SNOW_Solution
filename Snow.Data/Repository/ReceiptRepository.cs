using Snow.Data.Infrastructure;
using Snow.Model;
using Snow.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Snow.Data.Repository
{
    public class ReceiptRepository : RepositoryBase<Receipt>, IReceiptRepository
    {
        public ReceiptRepository(IDbFactory dbFactory)
           : base(dbFactory)
       {

       }
        public Receipt GetReceiptById(int id)
        {
            var receipt = DbContext.Receipts.Where(c => c.Id == id).FirstOrDefault();

            return receipt;
        }
        public override void Update(Receipt entity)
        {
            entity.UpdatedDate = DateTime.Now;
            base.Update(entity);
        }
    }
}