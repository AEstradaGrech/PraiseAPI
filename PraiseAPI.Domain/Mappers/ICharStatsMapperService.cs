using PraiseAPI.Domain.DTOs;
using PraiseAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraiseAPI.Domain.Mappers
{
    public interface ICharStatsMapperService : IMapperService<CharStats, CharStatsDto>
    {

        CharStats MapFromCharDto(CharacterDto dto);
    }
}
