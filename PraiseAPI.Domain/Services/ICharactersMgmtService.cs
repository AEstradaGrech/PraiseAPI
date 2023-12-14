using PraiseAPI.Domain.DTOs;
using PraiseAPI.Domain.DTOs.RequestModels.Filters;
using PraiseAPI.Infrastructure.Utilities.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraiseAPI.Domain.Services
{
    public interface ICharactersMgmtService
    {
        CollectionResponse<CharacterDto> GetByFilter_DAO(CharactersDaoFilter filter);
        SingleResponse<CharacterDto> Post(CharacterDto dto);
    }
}
