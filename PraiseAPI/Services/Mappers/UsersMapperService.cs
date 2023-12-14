using Omu.ValueInjecter;
using PraiseAPI.Domain.DTOs.User;
using PraiseAPI.Domain.Entities;
using PraiseAPI.Domain.Mappers;

namespace PraiseAPI.Services.Mappers
{
    public class UsersMapperService : IUsersMapperService
    {
        private readonly Lazy<ICharactersMapperService> _charsMapper;

        public UsersMapperService(IServiceProvider services)
        {
            _charsMapper = new Lazy<ICharactersMapperService>(() => services.GetRequiredService<ICharactersMapperService>());
        }

        public UserDto MapToDto(PraiseUser entity)
        {
            UserDto dto = new UserDto();
            
            dto = (UserDto)dto.InjectFrom(entity);

            dto.CreationDate = entity.SignUpDate;

            if(entity.Characters.Count > 0 && entity.Characters.Any(e => e.IsCurrentCharacter))
                dto.CurrentCharacter = _charsMapper.Value.MapToDto(entity.Characters.SingleOrDefault(c => c.IsCurrentCharacter == true));

            return dto;
        }

        public PraiseUser MapToEntity(UserDto dto)
        {
            PraiseUser user = new PraiseUser();

            user = (PraiseUser)user.InjectFrom(dto);

            if(dto.CreationDate.HasValue)
                user.SignUpDate = dto.CreationDate.Value;

            if(dto.CurrentCharacter != null)
                user.Characters.Add(_charsMapper.Value.MapToEntity(dto.CurrentCharacter));

            return user;
        }

        public FullUserDto MapToFullUser(PraiseUser entity)
        {
            var dto = new FullUserDto();

            dto = (FullUserDto)dto.InjectFrom(entity);

            if(entity.Characters.Count > 0)
                entity.Characters.ForEach(c => dto.UserCharacters.Add(_charsMapper.Value.MapToDto(c)));

            return dto;
        }

        public List<UserDto> MapManyToDto(IEnumerable<PraiseUser> entities)
        {
            List<UserDto> dtos = new List<UserDto>();

            foreach (var entity in entities)
                dtos.Add(MapToDto(entity));

            return dtos;
        }

        public GameUserDto MapToGameUser(PraiseUser entity)
        {
            GameUserDto dto = new GameUserDto();

            dto = (GameUserDto)dto.InjectFrom(entity);

            dto.CreationDate = entity.SignUpDate;

            if(entity.Characters.Count > 0)
            {
                if(entity.Characters.Any(c => c.IsCurrentCharacter))
                {
                    dto.CurrentCharName = entity.Characters.SingleOrDefault(c => c.IsCurrentCharacter == true).Name;

                    dto.Characters = entity.Characters.Select(c => c.Name).ToList();
                }
            }

            return dto;
        }
    }
}
