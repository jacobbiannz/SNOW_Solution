using SNOW_Solution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snow.Service.Interface
{
    public interface IImageService
    {
        IEnumerable<Image> GetImages(int productId);
        Image GetImage(int id);
        void CreateImage(Image image);
        void SaveImage();
    }
}
