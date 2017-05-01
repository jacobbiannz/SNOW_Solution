//using Snow.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snow.Model;
using Snow.Data.Repository;
using Snow.Data.Infrastructure;
using Snow.Data.Repository.Interface;
using Snow.Model.Models;
//using Snow.Data.Repository;

namespace Snow.Service
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _ImageRepository;
        private readonly IImageInfoRepository _ImageInfoRepository;
        private readonly IUnitOfWork unitOfWork;

        public ImageService(IImageRepository imageRepository, IImageInfoRepository imageInfoRepository, IUnitOfWork unitOfWork)
        {
            _ImageRepository = imageRepository;
            _ImageInfoRepository = imageInfoRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IProductService Members

        public void Create(Image image)
        {
            _ImageRepository.Add(image);
        }

        public void CreateImage(Image image)
        {
            _ImageRepository.Add(image);
        }

        public Image GetImage(int id)
        {
            var iamge = _ImageRepository.GetById(id);
            return iamge;
        }

        public IList<Image> GetImages(int productId)
        {
            var images = new List<Image>();
            if (string.IsNullOrEmpty(productId.ToString()))
                return _ImageRepository.GetAll().ToList();
            else
            {
                var imageInfos = _ImageInfoRepository.GetAll().Where(c => c.ProductId == productId);

                foreach(var info in imageInfos)
                {
                    images.Add(GetImage(info.ImageIdentity));
                }
            }

            return images;
        }


        public void SaveImage()
        {
            unitOfWork.Commit();
        }

        public Task<int> SaveImageAsync()
        {
           return unitOfWork.CommitAsync();
        }

        #endregion
    }
}
