using Microsoft.Extensions.Configuration;
using PraiseAPI.Domain.DTOs;
using PraiseAPI.Domain.DTOs.RequestModels;
using PraiseAPI.Domain.DTOs.RequestModels.Filters;
using PraiseAPI.Domain.Entities;
using PraiseAPI.Domain.Repositories.DAOs;
using PraiseAPI.Domain.Services;
using PraiseAPI.Infrastructure.Extensions;
using PraiseAPI.Infrastructure.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace PraiseAPI.Infrastructure.Repositories.DAOs
{
    public class CharactersDAO : BaseDAO<PraiseCharacter>, ICharactersDAO
    {
        public CharactersDAO(IConfiguration appConfig, IApiLogService apiLog) : base(appConfig, apiLog) { }

        public PraiseCharacter GetByCmd(DbCommand cmd)
        {
            throw new NotImplementedException();
        }

        public List<CharacterDto> GetCharactersByFilter(CharactersDaoFilter filter)
        {
            var handler = new DbProcedureHandler("sp_Sel_Characters");

            handler.SetParams(filter);

            using DbCommand cmd = _dB.GetStoredProcCommand(handler.ProcName);

            cmd.SetupCommand(handler, _dB)
               .AddDataTableParam(filter.FACTIONS, nameof(filter.FACTIONS));

            return GetCollectionByCmd<CharacterDto>(cmd);
        }
    }
}
