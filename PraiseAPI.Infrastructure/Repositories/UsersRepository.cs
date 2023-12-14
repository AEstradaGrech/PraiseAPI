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
    public class UsersRepository : BaseRepository<PraiseUser>, IUsersRepository
    {
        
        public UsersRepository(PraiseDbContext ctx, IStringLocalizer<DbError> errorLoc) : base(ctx, errorLoc) { }

        public override bool CanAdd(PraiseUser newUser, out ApiError outError)
        {
            if (string.IsNullOrEmpty(newUser.Email) || string.IsNullOrEmpty(newUser.NickName))
            {
                outError = new ApiError(-1, _errorLoc["INSERT-InvalidId"]);
                return false;
            }

            if (CheckUserExists(newUser.Email))
            {
                outError = new ApiError(-1, _errorLoc["INSERT-Email"]);
                return false;
            }
            if (!IsValidNickname(newUser.NickName))
            {
                outError = new ApiError(-1, _errorLoc["INSERT-Nickname"]);
                return false;
            }

            outError = new ApiError();

            return true;
        }

        public bool CheckUserExists(string email)
            => DbSet.Any(x => x.Email == email);

        public bool IsValidNickname(string nickname)
            => !DbSet.Any(x => x.NickName == nickname);

        public PraiseUser GetByEmail(string email)
            => DbSet.Any(x => x.Email == email) ?
                DbSet.Include(x => x.Characters)
                        .ThenInclude(c =>
                            c.CharStats.Where(s => s.LevelUpDate == null)
                                       .Take(1))
                .SingleOrDefault(x => x.Email == email) : null;

        public PraiseUser GetByNickname(string nickname)
            => DbSet.Any(x => x.NickName == nickname) ? 
                DbSet.Include(x => x.Characters)
                        .ThenInclude(c => 
                            c.CharStats.Where(s => s.LevelUpDate == null)
                                       .Take(1))
                .SingleOrDefault(x => x.NickName == nickname)
                : null;

       
    }
}
