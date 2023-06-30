﻿namespace Users.ViewModels.Base
{
    public class PagingRequestBase: RequestBase
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
