using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Application.Dtos;

namespace Users.Application.Catalog.Products.Dtos.Manage
{
    public class GetProductPagingRequest : PagingRequestBase
    {
        public string KeyWord { get; set; }
        public List<int> CategoryIDs { get; set; }
    }
}
