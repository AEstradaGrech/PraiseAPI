using PraiseAPI.Domain.Entities;

namespace PraiseAPI.Domain.Repositories
{
    public interface IUserRolesRepository : IRepository<UserRole>
    {
        IEnumerable<UserRole> GetUserRoles(int userId);
        UserRole GetUserRole(int userId, int roleId);
        bool HasRoleAssigned(int userId, int roleId);
    }
}
