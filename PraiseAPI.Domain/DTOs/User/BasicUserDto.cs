namespace PraiseAPI.Domain.DTOs.User
{
    public class BasicUserDto
    {
        public BasicUserDto() { }

        public string NickName { get; set; }
        public string Email { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public DateTime? LastConnectionDate { get; set; }
        public bool IsLogged { get; set; }
        public float ToliCoins { get; set; }
    }
}
