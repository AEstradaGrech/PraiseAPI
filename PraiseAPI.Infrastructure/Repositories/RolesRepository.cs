using Microsoft.Extensions.Localization;
using PraiseAPI.Domain.Entities;
using PraiseAPI.Domain.Repositories;
using PraiseAPI.Infrastructure.Context;
using PraiseAPI.Infrastructure.Resources;
using PraiseAPI.Infrastructure.Utilities.ResponseModels;

namespace PraiseAPI.Infrastructure.Repositories
{
    public class RolesRepository : BaseRepository<Role>, IRolesRepository
    {
        public RolesRepository(PraiseDbContext ctx, IStringLocalizer<DbError> errorLoc) : base(ctx, errorLoc) { }

        public Role GetByName(string name)
            => DbSet.Any(x => x.Name == name) ?
               DbSet.SingleOrDefault(x => x.Name == name) : null;

        public override bool CanAdd(Role entity, out ApiError outError)
        {
            if(DbSet.Any(x => x.Name == entity.Name))
            {
                outError = new ApiError(-1, _errorLoc["DbError-INSERT"] + " - Ya existe un rol con ese mismo nombre en DB");
                return false;
            }

            if (DbSet.Any(x => x.DisplayName == entity.DisplayName))
            {
                outError = new ApiError(-1, _errorLoc["DbError-INSERT"] + " - Ya existe un rol con el mismo DisplayName");
                return false;
            }
            if (DbSet.Any(x => x.Description == entity.Description))
            {
                outError = new ApiError(-1, _errorLoc["DbError-INSERT"] + " - Ya existe un rol con la misma Descripción");
                return false;
            }

            outError = new ApiError();
            return true;
        }

    }
}
