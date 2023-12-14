using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraiseAPI.Domain.Entities
{
    public class PraiseUser : Entity
    {
        public PraiseUser() 
        { 
            Characters = new List<PraiseCharacter>();
            Roles = new List<UserRole>();
        }

        public string NickName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime SignUpDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public DateTime? LastConnectionDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public bool IsLogged { get; set; }
        // public string CurrentToken { get;set; } <-- en login Update IsLogged & Token. en logout se borra. en Policy -> check Roles & Token --> si !User.IsLogged || CurrentToken == "" || CurrentToken != Token return false
        public float ToliCoins { get; set; }
        public List<PraiseCharacter> Characters { get; set; }
        public List<UserRole> Roles { get; set; }
        
    }
}
