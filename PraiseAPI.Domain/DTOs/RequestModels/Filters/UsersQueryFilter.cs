using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraiseAPI.Domain.DTOs.RequestModels.Filters
{
    public class UsersQueryFilter : BaseQueryFilter
    {
        public string UserNickname { get; set; }
        public string UserEmail { get; set; }
        public bool? IsLogged { get; set; }
        public bool? IsPlaying { get; set; }
        public DateTime? CreationDateFrom { get; set; }
        public DateTime? CreationDateTo { get; set; }
        public float? MinToliCoins { get; set; }
        public float? MaxToliCoins { get; set; }
        public int CharFactionId { get; set; }
        public bool? IsActive { get; set; }
    }
}
