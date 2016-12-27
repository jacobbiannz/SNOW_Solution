using SNOW_Solution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNOW_Solution.Repository
{
    public interface IGenericRepository<T> where T: BaseEntity
    {
        IEnumerable<BaseEntity> SelectAll();
        BaseEntity SelectByID(object id);
        void Insert(BaseEntity obj);
        void Update(BaseEntity obj);
        void Delete(object id);
        void Save();
    }
}
