using Snow.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SNOW_Solution.Models;
using SNOW_Solution.Repository;
using Snow.Data.Infrastructure;
using Snow.Data.Repository;

namespace Snow.Service
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository imageRepository;
        private readonly IUnitOfWork unitOfWork;

        public ImageService(IImageRepository imageRepository, IUnitOfWork unitOfWork)
        {
            this.imageRepository = imageRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IProductService Members

        public void Create(Image image)
        {
            imageRepository.Add(image);
        }

        public void CreateImage(Image image)
        {
            imageRepository.Add(image);
        }

        public Image GetImage(int id)
        {
            var iamge = imageRepository.GetById(id);
            return iamge;
        }

        public IEnumerable<Image> GetImages(int productId)
        {
            if (string.IsNullOrEmpty(productId.ToString()))
                return imageRepository.GetAll();
            else
                return imageRepository.GetAll().Where(c => c.ProductId == productId);
        }


        public void SaveImage()
        {
            unitOfWork.Commit();
        }

        #endregion
    }
}
