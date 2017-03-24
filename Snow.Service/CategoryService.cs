using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snow.Model;
using Snow.Data.Repository;
////using Snow.Data.Repository.Interface;
using Snow.Data.Infrastructure;

namespace Snow.Service
{
    class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        #region ICategoryService Members

        public void CreateCategory(Category Category)
        {
            _categoryRepository.Add(Category);
        }
        public void UpdateCategory(Category Category)
        {
            _categoryRepository.Update(Category);
        }
        public void DeleteCategory(Category Category)
        {
            _categoryRepository.Delete(Category);
        }

        public Category GetCategory(string name)
        {
            var Category = _categoryRepository.GetCategoryByName(name);
            return Category;
        }

        public Category GetCategory(int id)
        {
            var Category = _categoryRepository.GetById(id);
            return Category;
        }

        public IEnumerable<Category> GetCategories(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return _categoryRepository.GetAll();
            return _categoryRepository.GetAll().Where(c => c.Name == name);

        }
        public void SaveCategory()
        {
            _unitOfWork.Commit();
        }
        public Task<int> SaveCategoryAsync()
        {
            return _unitOfWork.CommitAsync();
        }
        #endregion
    }
}
