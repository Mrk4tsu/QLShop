using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.ViewModels.Base
{
    public class ApiSuccessResult<T> : ApiResult<T>
    {
        public string[] ValidatioError { get; set; }
        public ApiSuccessResult()
        {
        }
        public ApiSuccessResult(string message) {
            IsSuccessed = false;
            Message = message;
        }
        public ApiSuccessResult(string[] validatioError)
        {
            IsSuccessed = false;
            ValidatioError = validatioError;
        }
    }
}
