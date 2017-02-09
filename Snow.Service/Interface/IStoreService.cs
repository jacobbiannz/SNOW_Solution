using SNOW_Solution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snow.Service.Interface
{
    public interface IStoreService
    {
        IEnumerable<Store> GetStores(string name = null);

    }
}
