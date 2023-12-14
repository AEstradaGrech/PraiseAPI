namespace PraiseAPI.Domain.DTOs.User
{
    public class FullUserDto : BasicUserDto
    {
        public FullUserDto() : base() { UserCharacters = new List<CharacterDto>(); }

        public List<CharacterDto> UserCharacters { get; set; }
    }
}
