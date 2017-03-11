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
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public Category GetCategoryByName (string categoryName)
        {
            var category = DbContext.Categories.Where(c => c.Name == categoryName).FirstOrDefault();

            return category;
        }

        public override void Update(Category entity)
        {
            entity.UpdatedDate = DateTime.Now;
            base.Update(entity);
        }
    }
}
