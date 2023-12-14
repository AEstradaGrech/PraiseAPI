using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PraiseAPI.Domain.DTOs.User;

namespace PraiseAPI.Domain.DTOs.RequestModels
{
    public class GameSignUpRequest : Login
    {
        public UserDto PraiseUser { get; set; }
    }
}
