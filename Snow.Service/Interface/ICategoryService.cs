using Snow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snow.Service
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories(string name = null);

    }
}
