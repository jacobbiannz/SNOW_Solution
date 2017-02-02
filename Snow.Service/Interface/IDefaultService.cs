using SNOW_Solution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snow.Service.Interface
{
    public interface IDefaultService
    {
        IEnumerable<Company> GetCompanies(int comapnyId);
        IEnumerable<Category> GetCategories(int categoryId);
        IEnumerable<Brand> GetBrands(int brandId);
        IEnumerable<Store> GetStores(int storeId);
       
    }
}
