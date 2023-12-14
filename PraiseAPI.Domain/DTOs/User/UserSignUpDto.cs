
using System.ComponentModel.DataAnnotations;

namespace PraiseAPI.Domain.DTOs.User
{
    public class UserSignUpDto : UserDto
    {
        public UserSignUpDto() : base() { }

        [Required]
        [MaxLength(20)]
        [MinLength(6)]
        public string UserPassword { get; set; }
    }
}
