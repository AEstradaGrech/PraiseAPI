using System.Text.Json.Serialization;

namespace PraiseAPI.Domain.DTOs.RequestModels.Filters
{
    public class CharactersDaoFilter : BaseQueryFilter
    {
        [JsonPropertyName("CharName")]
        public string? CHAR_NAME { get; set; }
        [JsonPropertyName("FactionIds")]
        public List<int> FACTIONS { get; set; }
        [JsonPropertyName("CharSex")]
        public int? CHAR_SEX { get; set; }
        [JsonPropertyName("CreationDate")]
        public DateTime? DT_CREATION { get; set; }
        [JsonPropertyName("IsCurrentCharacter")]
        public bool? BT_IS_CURRENT { get; set; }
    }
}
