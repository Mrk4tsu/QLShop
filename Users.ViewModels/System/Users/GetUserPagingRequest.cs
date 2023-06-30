using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.ViewModels.Base;

namespace Users.ViewModels.System.Users
{
	public class GetUserPagingRequest : PagingRequestBase
	{
		public string Keyword { get; set; }
	}
}
