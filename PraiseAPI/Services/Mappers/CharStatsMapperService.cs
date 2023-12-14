using Microsoft.EntityFrameworkCore;
using Omu.ValueInjecter;
using PraiseAPI.Domain.DTOs;
using PraiseAPI.Domain.Entities;
using PraiseAPI.Domain.Mappers;

namespace PraiseAPI.Services.Mappers
{
    public class CharStatsMapperService : ICharStatsMapperService
    {
        public CharStatsDto MapToDto(CharStats entity)
        {
            CharStatsDto dto = new CharStatsDto();

            dto = (CharStatsDto)dto.InjectFrom(entity);

            return dto;
        }

        public CharStats MapToEntity(CharStatsDto dto)
        {
            CharStats entity = new CharStats();

            entity = (CharStats)entity.InjectFrom(dto);

            return entity;
        }

        public List<CharStatsDto> MapManyToDto(IEnumerable<CharStats> entities)
        {
            List<CharStatsDto> dtos = new List<CharStatsDto>();

            foreach (var entity in entities)
                dtos.Add(MapToDto(entity));

            return dtos;
        }

        public CharStats MapFromCharDto(CharacterDto dto)
        {
            var entityStats = new CharStats();

            entityStats.Strenght = dto.Strenght;
            entityStats.Constitution = dto.Constitution;
            entityStats.Dextrity = dto.Dextrity;
            entityStats.Intelligence = dto.Intelligence;
            entityStats.Wisdom = dto.Wisdom;
            entityStats.Charisma = dto.Charisma;
            entityStats.Luck = dto.Luck;
            entityStats.MaxHealth = dto.MaxHealth;
            entityStats.MaxStamina = dto.MaxStamina;
            entityStats.Level = dto.Level;
            entityStats.CharExp = dto.CurrentExp;
            entityStats.LevelUpExp = dto.LevelUpExp;

            return entityStats;
        }

    }
}
