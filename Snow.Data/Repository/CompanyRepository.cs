using Snow.Data.Infrastructure;
//using Snow.Data.Repository.Interface;
using Snow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snow.Data.Repository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
        public Company GetCompanyByName(string companyName)
        {
            var company = DbContext.Companys.Where(c => c.Name == companyName).FirstOrDefault();

            return company;
        }

        public override void Update(Company entity)
        {
            entity.UpdatedDate = DateTime.Now;
            base.Update(entity);
        }
    }
}
