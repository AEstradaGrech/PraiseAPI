using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraiseAPI.Domain.DTOs.ResponseModels
{
    public class LoginResponse
    {
        public LoginResponse() { }
        
        public LoginResponse(string userName, string email, string accessToken, DateTime expirationDate)
        {
            UserName = userName;
            UserEmail = email;
            AccessToken = accessToken;
            ExpirationDate = expirationDate;
        }
        
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string AccessToken { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
