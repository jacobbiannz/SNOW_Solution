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

        public IEnumerable<ImageInfo> GetImageInfosById(int productId)
        {
            var imageInfos = DbContext.ImageInfos.Where(c => c.ProductId == productId);

            return imageInfos;
        }
    }
}
