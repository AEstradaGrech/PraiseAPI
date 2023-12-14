using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraiseAPI.Domain.DTOs.RequestModels
{
    public class Login
    {
        public Login() 
        {
            UserName = string.Empty;
            UserEmail = string.Empty;
        }
       
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }
    }
}
