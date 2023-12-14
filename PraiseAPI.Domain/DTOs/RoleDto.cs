using System.ComponentModel.DataAnnotations;

namespace PraiseAPI.Domain.DTOs
{
    public class RoleDto
    {
        public RoleDto()
        {
            DisplayName = string.Empty;
            IsPublic = false;
        }

        [Required]
        public string Name { get; set; }
        public string DisplayName { get; set; }
        [Required]
        public string Description { get; set; }
        public bool IsPublic { get; set; }
    }
}
