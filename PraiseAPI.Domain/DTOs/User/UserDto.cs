namespace PraiseAPI.Domain.DTOs.User
{
    public class UserDto : BasicUserDto
    {
        public UserDto() : base()
        {
            CurrentCharacter = null;
        }

        public CharacterDto? CurrentCharacter { get; set; }
    }
}
