
namespace PraiseAPI.Domain.Entities
{
    public class UserRole : Entity
    {
        public UserRole() { }
        
        public UserRole(int userId, int roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }

        public UserRole(PraiseUser user, Role role)
        {
            User = user;
            Role = role;
        }

        public PraiseUser User { get; set; }
        public int UserId { get; set; }
        public Role Role { get; set; }
        public int RoleId { get; set; }
    }
}
