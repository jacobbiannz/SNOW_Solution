using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snow.Service
{
    public interface IValidate
    {
        void InitializeVlidation(IValidationDictionary validationDictionary);
    }
}
