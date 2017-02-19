using Snow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snow.Service
{
    public interface ICompanyService
    {
        IEnumerable<Company> GetCompanies(string name = null);

    }
}
