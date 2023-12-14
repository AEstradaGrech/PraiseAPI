
using PraiseAPI.Domain.DTOs;
using PraiseAPI.Infrastructure.Utilities.ResponseModels;

namespace PraiseAPI.Domain.Services
{
    public interface IRolesMgmtService
    {
        SingleResponse<RoleDto> GetRole(int roleId);
        SingleResponse<RoleDto> GetRole(string name);
        SingleResponse<RoleDto> AddRole(RoleDto roleDto);
        SingleResponse<RoleDto> UpdateRole(RoleDto roleDto);
        SingleResponse<RoleDto> DeleteRole(string roleName);
        CollectionResponse<RoleDto> GetRoles();
        CollectionResponse<RoleDto> GetUserRoles(int userId);
        CollectionResponse<RoleDto> GetUserRoles(string userName);
        SingleResponse<RoleDto> AddUserRole(int userId, int roleId);
        SingleResponse<RoleDto> AddUserRole(string userName, string roleName);
        SingleResponse<RoleDto> RemoveUserRole(int userId, int roleId);
        SingleResponse<RoleDto> RemoveUserRole(string userName, string roleName);
    }
}
