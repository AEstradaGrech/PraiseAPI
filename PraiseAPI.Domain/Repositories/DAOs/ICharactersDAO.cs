using PraiseAPI.Domain.DTOs;
using PraiseAPI.Domain.DTOs.RequestModels.Filters;
using PraiseAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraiseAPI.Domain.Repositories.DAOs
{
    public interface ICharactersDAO : IBaseDAO<PraiseCharacter>
    {
        List<CharacterDto> GetCharactersByFilter(CharactersDaoFilter filter);
    }
}
