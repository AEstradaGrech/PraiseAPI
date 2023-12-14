using PraiseAPI.Domain.Entities;
using PraiseAPI.Infrastructure.Utilities.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraiseAPI.Domain.Repositories
{
    public interface ICharactersRepository : IRepository<PraiseCharacter>
    {
        PraiseCharacter AddNew(PraiseCharacter character);
        bool CanAdd(PraiseCharacter character, out ApiError outError);
        bool IsValidName(string charName);
    }
}
