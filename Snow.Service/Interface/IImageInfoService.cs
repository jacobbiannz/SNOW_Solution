using Snow.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snow.Service.Interface
{
    public interface IImageInfoService
    {
        IEnumerable<ImageInfo> GetImageInfos(int productId);
        ImageInfo GetImageInfo(int id);
        void CreateImageInfo(ImageInfo imageInfo);
        void SaveImageInfo();
        Task<int> SaveImageInfoAsync();
    }
}
