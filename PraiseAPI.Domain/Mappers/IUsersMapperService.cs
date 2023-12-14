using PraiseAPI.Domain.DTOs.User;
using PraiseAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraiseAPI.Domain.Mappers
{
    public interface IUsersMapperService : IMapperService<PraiseUser, UserDto>
    {
        FullUserDto MapToFullUser(PraiseUser entity);
        GameUserDto MapToGameUser(PraiseUser entity);
    }
}
