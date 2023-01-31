using System;
using System.Collections.Generic;
using System.Net;

namespace api.Domain.VM.Shared
{
    public class Pagination<T> where T : class
    {
        public int Page { get; set; }

        public int PageSize { get; set; }

        public int TotalAmount { get; set; }

        public int TotalPages => (int)Math.Ceiling((decimal)TotalAmount / PageSize);

        public IEnumerable<T> Results { get; set; }
    }
}
