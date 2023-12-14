using Microsoft.Extensions.Localization;
using PraiseAPI.Domain.Entities;
using PraiseAPI.Domain.Repositories;
using PraiseAPI.Infrastructure.Context;
using PraiseAPI.Infrastructure.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraiseAPI.Infrastructure.Repositories
{
    public class CharStatsRepository : BaseRepository<CharStats>, ICharStatsRepository 
    {
        public CharStatsRepository(PraiseDbContext ctx, IStringLocalizer<DbError> errorLoc) : base(ctx, errorLoc) { }
    }
}
