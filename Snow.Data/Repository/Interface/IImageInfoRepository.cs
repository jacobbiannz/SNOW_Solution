using Snow.Data.Infrastructure;
using Snow.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snow.Data.Repository.Interface
{
    public interface IImageInfoRepository : IRepository<ImageInfo>
    {
        IEnumerable<ImageInfo> GetImageInfosById(int productId);
    }
}
