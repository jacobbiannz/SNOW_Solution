using Snow.Data.Infrastructure;
using SNOW_Solution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snow.Data.Repository
{
    public interface IImageRepository : IRepository<Image>
    {
        Image GetImageById(int productId);
    }
}
