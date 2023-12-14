using PraiseAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraiseAPI.Domain.Mappers
{
    public interface IMapperService<TEntity, TDto> where TEntity : Entity where TDto : class
    {
        public TEntity MapToEntity(TDto dto);
        public TDto MapToDto(TEntity entity);
        public List<TDto> MapManyToDto(IEnumerable<TEntity> entities);
    }
}
