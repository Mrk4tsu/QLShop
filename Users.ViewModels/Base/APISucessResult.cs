using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.ViewModels.Base
{
    public class APISucessResult<T> : APIResult<T>
    {
        public APISucessResult(T resultObj)
        {
            IsSuccessed = true;
            ResultObject = resultObj;
        }
        public APISucessResult()
        {
            IsSuccessed = true;
        }
    }
}
