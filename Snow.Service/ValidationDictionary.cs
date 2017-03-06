using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Snow.Service
{
    public class ValidationDictionary : IValidationDictionary
    {
        private ModelStateDictionary _modelState;
        
        public ValidationDictionary(ModelStateDictionary modelState)
        {
            _modelState = modelState;
        }
        public void AddError(string key, string errorMessage)
        {
            _modelState.AddModelError(key, errorMessage);
        }

        public bool IsValid
        {
            get { return _modelState.IsValid; }
        }
    }
}
