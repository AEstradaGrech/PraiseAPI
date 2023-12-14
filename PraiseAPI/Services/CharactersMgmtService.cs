using Microsoft.Extensions.Localization;
using PraiseAPI.Domain.DTOs;
using PraiseAPI.Domain.DTOs.RequestModels.Filters;
using PraiseAPI.Domain.Mappers;
using PraiseAPI.Domain.Repositories;
using PraiseAPI.Domain.Repositories.DAOs;
using PraiseAPI.Domain.Services;
using PraiseAPI.Infrastructure.Utilities.ResponseModels;
using PraiseAPI.Resources;

namespace PraiseAPI.Services
{
    public class CharactersMgmtService : BaseMgmtService, ICharactersMgmtService
    {
        private readonly ICharactersRepository _charactersRepository;
        private readonly ICharactersDAO _charactersDAO;
        private readonly ICharactersMapperService _charsMapper;
        private Lazy<IUsersRepository> _usersRepo;
        public CharactersMgmtService(ICharactersRepository charsRepo, ICharactersDAO charsDAO, ICharactersMapperService charsMapper, IServiceProvider services,
            IApiLogService logService, IStringLocalizer<ErrorMsg> errorLoc) : base(logService, errorLoc)
        {
            _charactersRepository = charsRepo;
            _charactersDAO = charsDAO;
            _charsMapper = charsMapper;
            _usersRepo = new Lazy<IUsersRepository>(() => services.GetRequiredService<IUsersRepository>());
           
        }

        public CollectionResponse<CharacterDto> GetByFilter_DAO(CharactersDaoFilter filter)
        {
            var entities = _charactersDAO.GetCharactersByFilter(filter);

            if (entities.Count > 0)
            {

            }

            var dtos = new List<CharacterDto>();

            return new CollectionResponse<CharacterDto>(dtos);
        }

        public SingleResponse<CharacterDto> Post(CharacterDto dto)
        {
            if(dto.OwningUserId == 0)
            {
                if (string.IsNullOrEmpty(dto.OwningUserName))
                    return new SingleResponse<CharacterDto>(-1, $"{nameof(CharactersMgmtService)}-{nameof(Post)} - " + _errorLoc["MgmtError-CHAR_POST_NO_OWNER"]);

                var owner = _usersRepo.Value.GetByNickname(dto.OwningUserName);

                if(owner == null)
                    return new SingleResponse<CharacterDto>(-1, $"{nameof(CharactersMgmtService)}-{nameof(Post)} - " + _errorLoc["MgmtError-OWNERNAME_NOT_FOUND"]);
            }

            var entity = _charsMapper.MapToEntity(dto);


            var dbError = new ApiError();
            if (!_charactersRepository.CanAdd(entity, out dbError))
                return new SingleResponse<CharacterDto>(-1, dbError.Msg);

            var newEntity = _charactersRepository.AddNew(entity);

            return newEntity != null ?
                new SingleResponse<CharacterDto>(_charsMapper.MapToDto(newEntity)) :
                new SingleResponse<CharacterDto>(-1, $"{nameof(CharactersMgmtService)}-{nameof(Post)} - " + _errorLoc["DbError-POST"]);
        }
    }
}
