namespace PraiseAPI.Domain.DTOs.User
{
    public class GameUserDto : BasicUserDto
    {
        public GameUserDto() : base()
        {
            Characters = new List<string>();
        }

        public string CurrentCharName { get; set; }
        public string CharSaveGameSlot { get; set; }
        public List<string> Characters { get; set; }
    }
}
