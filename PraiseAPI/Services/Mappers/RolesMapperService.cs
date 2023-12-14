using Omu.ValueInjecter;
using PraiseAPI.Domain.DTOs;
using PraiseAPI.Domain.Entities;
using PraiseAPI.Domain.Mappers;

namespace PraiseAPI.Services.Mappers
{
    public class RolesMapperService : IRolesMapperService
    {
        public RoleDto MapToDto(Role entity)
        {
            var dto = new RoleDto();

            dto = (RoleDto)dto.InjectFrom(entity);

            return dto;
        }

        public Role MapToEntity(RoleDto dto)
        {
            var entity = new Role();

            entity = (Role)entity.InjectFrom(dto);

            return entity;
        }

        public List<RoleDto> MapManyToDto(IEnumerable<Role> entities)
        {
            var dtos = new List<RoleDto>();

            foreach(var entity in entities)
                dtos.Add(MapToDto(entity));

            return dtos;
        }
    }
}
