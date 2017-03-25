using Snow.Data.Infrastructure;
using Snow.Data.Repository;
using Snow.Data.Repository.Interface;
using Snow.Model.Models;
using Snow.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snow.Service
{
   public class ImageInfoService : IImageInfoService
    {
        private readonly IImageInfoRepository _ImageInfoRepository;
        private readonly IUnitOfWork unitOfWork;

        public ImageInfoService(IImageInfoRepository imageInfoRepository, IUnitOfWork unitOfWork)
        {
            _ImageInfoRepository = imageInfoRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IProductService Members

        public void Create(ImageInfo imageInfo)
        {
            _ImageInfoRepository.Add(imageInfo);
        }

        public void CreateImageInfo(ImageInfo imageInfo)
        {
            _ImageInfoRepository.Add(imageInfo);
        }

        public ImageInfo GetImageInfo(int id)
        {
            var iamgeInfo = _ImageInfoRepository.GetById(id);
            return iamgeInfo;
        }

        public IEnumerable<ImageInfo> GetImageInfos(int productId)
        {
            if (string.IsNullOrEmpty(productId.ToString()))
                return _ImageInfoRepository.GetAll();
            else
                return _ImageInfoRepository.GetAll().Where(c => c.ProductId == productId);
        }


        public Task<int> SaveImageInfoAsync()
        {
            return unitOfWork.CommitAsync();
        }

        public void SaveImageInfo()
        {
            unitOfWork.Commit();
        }

        #endregion
    }
}
