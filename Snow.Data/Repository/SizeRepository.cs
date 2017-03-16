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
    public class SizeRepository : RepositoryBase<Size>, ISizeRepository
    {
        public SizeRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public Size GetSizeByName(string SizeName)
        {
            var Size = DbContext.Sizes.Where(c => c.Name == SizeName).FirstOrDefault();

            return Size;
        }

        public override void Update(Size entity)
        {
            entity.UpdatedDate = DateTime.Now;
            base.Update(entity);
        }
    }
}
