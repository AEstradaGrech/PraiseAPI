using Omu.ValueInjecter;
using PraiseAPI.Domain.DTOs;
using PraiseAPI.Domain.Entities;
using PraiseAPI.Domain.Mappers;

namespace PraiseAPI.Services.Mappers
{
    public class CharactersMapperService : ICharactersMapperService
    {
        private readonly Lazy<ICharStatsMapperService> _statsMapper;

        public CharactersMapperService(IServiceProvider services)
        {
            _statsMapper = new Lazy<ICharStatsMapperService>(() => services.GetRequiredService<ICharStatsMapperService>());
        }
        public CharacterDto MapToDto(PraiseCharacter entity)
        {
            CharacterDto dto = new CharacterDto();

            dto = (CharacterDto)dto.InjectFrom(entity);

            if(entity.CharStats.Any(s => s.LevelUpDate == null))
            {
                var currentStats = entity.CharStats.SingleOrDefault(s => s.LevelUpDate == null);

                if (currentStats != null)
                    mapDtoStats(ref dto, currentStats);
            }

            if(entity.User != null)
            {
                dto.OwningUserId = entity.User.Id;
                dto.OwningUserName = entity.User.NickName;
            }

            return dto;
        }

        public PraiseCharacter MapToEntity(CharacterDto dto)
        {
            PraiseCharacter entity = new PraiseCharacter();

            entity = (PraiseCharacter)entity.InjectFrom(dto);

            entity.CharStats.Add(_statsMapper.Value.MapFromCharDto(dto));

            entity.UserId = dto.OwningUserId;

            return entity;
        }

        public List<CharacterDto> MapManyToDto(IEnumerable<PraiseCharacter> entities)
        {
            List<CharacterDto> dtos = new List<CharacterDto>();

            foreach (var entity in entities)
                dtos.Add(MapToDto(entity));

            return dtos;
        }

        private void  mapDtoStats(ref CharacterDto dto, CharStats stats)
        {
            dto.Strenght = stats.Strenght;
            dto.Constitution = stats.Constitution;
            dto.Dextrity = stats.Dextrity;
            dto.Intelligence = stats.Intelligence;
            dto.Wisdom = stats.Wisdom;
            dto.Charisma = stats.Charisma;
            dto.Luck = stats.Luck;
            dto.MaxHealth = stats.MaxHealth;
            dto.MaxStamina = stats.MaxStamina;
            dto.Level = stats.Level;
            dto.LevelUpExp = stats.LevelUpExp;
            dto.CurrentExp = stats.CharExp;
        }
    }
}
