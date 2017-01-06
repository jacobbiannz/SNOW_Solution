using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snow.Data.Infrastructure
{
    class DbFactory : Disposable, IDbFactory
    {
        SnowEntities dbContext;

        public SnowEntities Init()
        {
            return dbContext ?? (dbContext = new SnowEntities());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
