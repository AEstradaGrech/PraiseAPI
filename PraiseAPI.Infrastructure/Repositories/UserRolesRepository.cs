using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using PraiseAPI.Domain.Entities;
using PraiseAPI.Domain.Repositories;
using PraiseAPI.Infrastructure.Context;
using PraiseAPI.Infrastructure.Resources;
using PraiseAPI.Infrastructure.Utilities.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraiseAPI.Infrastructure.Repositories
{
    public class UserRolesRepository : BaseRepository<UserRole>, IUserRolesRepository
    {
        public UserRolesRepository(PraiseDbContext ctx, IStringLocalizer<DbError> errorLoc) : base(ctx, errorLoc) { }

        public override bool CanAdd(UserRole entity, out ApiError outError)
        {
            if(HasRoleAssigned(entity.UserId, entity.RoleId))
            {
                outError = new ApiError(-1, $"{nameof(UserRolesRepository)}-{nameof(CanAdd)} - " + "El usuario ya tiene ese rol asignado");
                return false;
            }

            outError = new ApiError();
            return true;
        }

        public UserRole GetUserRole(int userId, int roleId)
            => !HasRoleAssigned(userId, roleId) ? null : _dbSet.SingleOrDefault(x => x.UserId == userId && x.RoleId == roleId);

        public IEnumerable<UserRole> GetUserRoles(int userId)
            => _dbSet.Include(x => x.Role)
                     .Where(x => x.UserId == userId).AsEnumerable();

        public bool HasRoleAssigned(int userId, int roleId)
            => _dbSet.Any(x => x.UserId == userId && x.RoleId == roleId);
    }
}
