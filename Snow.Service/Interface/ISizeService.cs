using Snow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snow.Service
{
    public interface ISizeService
    {
        IEnumerable<Size> GetSizes(string name = null);
        Size GetSize(int id);
        Size GetSize(string name);
        void CreateSize(Size brand);
        void UpdateSize(Size brand);
        void DeleteSize(Size brand);
        void SaveSize();

    }
}
