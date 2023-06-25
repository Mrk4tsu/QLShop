using System.Collections.Generic;

namespace Users.ViewModels.Base
{
    public class PagedResult<T>
    {
        public List<T> Items { get; set; }
        public int TotalRecord { get; set; }
    }
}
