using Snow.Data.Infrastructure;
using Snow.Data.Repository.Interface;
using Snow.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snow.Data.Repository
{
    public class ImageInfoRepository : RepositoryBase<ImageInfo>, IImageInfoRepository
    {
        public ImageInfoRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public ImageInfo GetImageInfoById(int productId)
        {
            var imageInfo = DbContext.ImageInfos.Where(c => c.ProductId == productId).FirstOrDefault();

            return imageInfo;
        }
    }
}
