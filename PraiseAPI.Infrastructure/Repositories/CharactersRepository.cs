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
    public class CharactersRepository : BaseRepository<PraiseCharacter>, ICharactersRepository
    {
        public CharactersRepository(PraiseDbContext ctx, IStringLocalizer<DbError> errorLoc) : base(ctx, errorLoc) { }

        public PraiseCharacter AddNew(PraiseCharacter character)
        {
            character.CreationDate = DateTime.Now;
            character.ModificationDate = DateTime.Now;
            character.IsCurrentCharacter = true;

            if(DbSet.Any(x => x.UserId == character.UserId && x.IsCurrentCharacter == true))
            {
                DbSet.SingleOrDefault(x => x.UserId == character.UserId && x.IsCurrentCharacter == true).IsCurrentCharacter = false;
            }

            return Add(character);
        }

        public bool CanAdd(PraiseCharacter character, out ApiError outError)
        {
            if(character.UserId == 0)
            {
                outError = new ApiError(-1, _errorLoc["INSERT-NoCharOwner"]);
                return false;
            }

            if(DbSet.Any(x => x.UserId == character.UserId) && DbSet.Where(x => x.UserId == character.UserId).Count() >= 3)
            {
                outError = new ApiError(-1, _errorLoc["INSERT-MaxUserChars"]);
                return false;
            }

            if(!IsValidName(character.Name))
            {
                outError = new ApiError(-1, _errorLoc["INSERT-InvalidCharName"]);
                return false;
            }

            outError = new ApiError();

            return true;
        }

        public bool IsValidName(string charName)
            => !string.IsNullOrEmpty(charName) && !DbSet.Any(x => x.Name == charName);
    }
}
