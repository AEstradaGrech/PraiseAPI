using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraiseAPI.Domain.Entities
{
    public class Role : Entity
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }

        public string Description { get; set; }

        public List<UserRole> RoleUsers { get; set; }

        public bool IsPublic { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
