using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.ViewModels.Base
{
    public class APIErrorResult<T> : APIResult<T>
    {
        public string[] ValidatioError { get; set; }
        public APIErrorResult()
        {
        }
        public APIErrorResult(string message) {
            IsSuccessed = false;
            Message = message;
        }
        public APIErrorResult(string[] validatioError)
        {
            IsSuccessed = false;
            ValidatioError = validatioError;
        }
    }
}
