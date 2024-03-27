using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraiseAPI.Domain.DTOs.RequestModels.Filters
{
    public class RolesQueryFilter
    {
        public string? RoleName { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
    }
}
