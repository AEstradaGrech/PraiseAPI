using PraiseAPI.Domain.Entities;
using PraiseAPI.Infrastructure.Utilities.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraiseAPI.Domain.Repositories
{
    public interface IUsersRepository : IRepository<PraiseUser>
    {
        PraiseUser GetByNickname(string nickname);
        PraiseUser GetByEmail(string email);

        bool CanAdd(PraiseUser newUser, out ApiError outError);
        bool CheckUserExists(string email);
        bool IsValidNickname(string nickname);
    }
}
