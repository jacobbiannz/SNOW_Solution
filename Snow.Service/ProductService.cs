using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snow.Model;
using Snow.Data.Repository;
using Snow.Data.Infrastructure;

namespace Snow.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IUnitOfWork unitOfWork;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IProductService Members

        public void CreateProduct(Product product)
        {
            productRepository.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            productRepository.Update(product);
        }

        public Product GetProduct(string name)
        {
            var product = productRepository.GetProductByName(name);
            return product;
        }

        public Product GetProduct(int id)
        {
            var product = productRepository.GetById(id);
            var imageInfos = productRepository.GetImageInfos(id);
            product.AllImageInfos = imageInfos;
            return product;
        }

        public IEnumerable<Product> GetProducts(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return productRepository.GetAll();
            else
                return productRepository.GetAll().Where(c => c.Name == name);
        }

        public void SaveProduct()
        {
            unitOfWork.Commit();
        }
        #endregion
    }
}
