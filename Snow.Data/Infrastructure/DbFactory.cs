using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snow.Data.Infrastructure
{
   public class DbFactory : Disposable, IDbFactory
    {
        CompanyDBContext dbContext;

        public CompanyDBContext Init()
        {
            return dbContext ?? (dbContext = new CompanyDBContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
