using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraiseAPI.Domain.DTOs.RequestModels.Filters
{
    public class BaseQueryFilter
    {
        public int RequestedPage { get; set; }
        public int PageSize { get; set; }
        public int Sorting { get; set; }
    }
}
