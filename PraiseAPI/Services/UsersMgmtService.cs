using Microsoft.Extensions.Localization;
using MongoDB.Driver;
using PraiseAPI.Domain.DTOs.RequestModels;
using PraiseAPI.Domain.DTOs.RequestModels.Filters;
using PraiseAPI.Domain.DTOs.ResponseModels;
using PraiseAPI.Domain.DTOs.ResponseModels.Extensions;
using PraiseAPI.Domain.DTOs.User;
using PraiseAPI.Domain.Entities;
using PraiseAPI.Domain.Mappers;
using PraiseAPI.Domain.Repositories;
using PraiseAPI.Domain.Services;
using PraiseAPI.Infrastructure.Repositories;
using PraiseAPI.Infrastructure.Utilities.ResponseModels;
using PraiseAPI.Resources;

namespace PraiseAPI.Services
{
    public class UsersMgmtService : BaseMgmtService, IUsersMgmtService
    {
        private readonly IUsersMapperService _usersMapper;
        private readonly IUsersRepository _usersRepository;
        private readonly IRolesRepository _rolesRepository;
        private readonly IAuthService _authService;
        
        public UsersMgmtService(IUsersRepository usersRepo, IUsersMapperService usersMapper, IRolesRepository rolesRepo, IAuthService authService,
            IApiLogService logService, IStringLocalizer<ErrorMsg> errorLoc) : base(logService, errorLoc) 
        {
            _usersMapper = usersMapper;
            _usersRepository = usersRepo;
            _rolesRepository = rolesRepo;
            _authService = authService;
        }

        public CollectionResponse<UserDto> GetAll()
            => new CollectionResponse<UserDto>(_usersMapper.MapManyToDto(_usersRepository.GetAll()));

        public SingleResponse<UserDto> GetById(int id)
        {
            var entity = _usersRepository.GetById(id);

            if (entity == null)
                return new SingleResponse<UserDto>(-1, $"{nameof(UsersMgmtService)}-{nameof(GetAll)} - " + _errorLoc["DbError-GET"])
                    .LogResponse(_logService) as SingleResponse<UserDto>;

            return new SingleResponse<UserDto>(_usersMapper.MapToDto(entity));
        }
        
        public SingleResponse<UserDto> GetByNickName(string nickName)
        {
            var entity = _usersRepository.GetByNickname(nickName);

            if(entity == null)
                return new SingleResponse<UserDto>(-1, $"{nameof(UsersMgmtService)}-{nameof(GetByNickName)} - " + _errorLoc["DbError-GET"])
                    .LogResponse(_logService) as SingleResponse<UserDto>;

            return new SingleResponse<UserDto>(_usersMapper.MapToDto(entity));
        }
            
        public SingleResponse<UserDto> Post(UserSignUpDto userDto)
        {
            var mappedEntity = _usersMapper.MapToEntity(userDto);

            var userRole = _rolesRepository.GetByName(mappedEntity.Characters.Count > 0 ? "player" : "user");

            if (userRole == null)
                return new SingleResponse<UserSignUpDto>(-1, $"{nameof(RolesRepository)}-{nameof(_rolesRepository.GetByName)} - " + _errorLoc["DbError-POST"])
                     .LogResponse(_logService) as SingleResponse<UserDto>; ;

            mappedEntity.Roles.Add(new UserRole(mappedEntity, userRole));

            ApiError dbError = new ApiError();
            if (!_usersRepository.CanAdd(mappedEntity, out dbError))
                return new SingleResponse<UserDto>(-1, dbError.Msg);

            mappedEntity.SignUpDate = DateTime.Now;

            mappedEntity.Password = _authService.HashPass(userDto.UserPassword);

            var newEntity = _usersRepository.Add(mappedEntity);

            return newEntity != null ? 
                new SingleResponse<UserDto>(_usersMapper.MapToDto(newEntity)) : 
                new SingleResponse<UserDto>(-2, $"{nameof(UsersMgmtService)}-{nameof(Post)} - " + _errorLoc["DbError-POST"])
                .LogResponse(_logService) as SingleResponse<UserDto>;
        }

        public SingleResponse<UserDto> Update(UserDto userDto)
        {
            if (string.IsNullOrEmpty(userDto.Email))
                return new SingleResponse<UserDto>(-1, $"{nameof(UsersMgmtService)}-{nameof(_usersRepository.GetByEmail)} - " + _errorLoc["MgmtError-NO_EMAIL"]);

            var updatedEntity = _usersRepository.GetByEmail(userDto.Email);

            if (updatedEntity == null)
                return new SingleResponse<UserDto>(-1, $"{nameof(UsersMgmtService)}-{nameof(_usersRepository.GetByEmail)} - " + _errorLoc["DbError-GET"])
                    .LogResponse(_logService) as SingleResponse<UserDto>;

            updatedEntity.NickName = userDto.NickName;

            updatedEntity.ToliCoins = userDto.ToliCoins;
            
            updatedEntity.LastConnectionDate = userDto.LastConnectionDate;

            updatedEntity.IsLogged = userDto.IsLogged;

            updatedEntity.ModificationDate = DateTime.Now;

            var update = _usersRepository.Update(updatedEntity);

            return update != null ? 
                new SingleResponse<UserDto>(_usersMapper.MapToDto(update)) : 
                new SingleResponse<UserDto>(-2, $"{nameof(UsersMgmtService)}-{nameof(Update)} - " + _errorLoc["DbError-UPDATE"])
                .LogResponse(_logService) as SingleResponse<UserDto>;
        }

        public SingleResponse<UserDto> Delete(int id)
        {
            var deletedEntity = _usersRepository.DeleteById(id);

            return deletedEntity != null ? 
                new SingleResponse<UserDto>(_usersMapper.MapToDto(deletedEntity)) : 
                new SingleResponse<UserDto>(-2, $"{nameof(UsersMgmtService)}-{nameof(Delete)} - " + _errorLoc["DbError-DELETE"])
                .LogResponse(_logService) as SingleResponse<UserDto>;
        }

        public SingleResponse<UserDto> Delete(string userEmail)
        {
            var entity = _usersRepository.GetByEmail(userEmail);

            if (entity == null)
                return new SingleResponse<UserDto>(-1, $"{nameof(UsersMgmtService)}-{nameof(_usersRepository.GetByEmail)} - " + _errorLoc["DbError-GET"])
                    .LogResponse(_logService) as SingleResponse<UserDto>;

            var deletedEntity = _usersRepository.Delete(entity);

            return deletedEntity != null ? 
                new SingleResponse<UserDto>(_usersMapper.MapToDto(deletedEntity)) : 
                new SingleResponse<UserDto>(-2, $"{nameof(UsersMgmtService)}-{nameof(Delete)} - " + _errorLoc["DbError-DELETE"])
                .LogResponse(_logService) as SingleResponse<UserDto>;
        }

        public SingleResponse<UserDto> Discharge(string userEmail)
        {
            var entity = _usersRepository.GetByEmail(userEmail);

            if (entity == null)
                return new SingleResponse<UserDto>(-1, $"{nameof(UsersMgmtService)}-{nameof(_usersRepository.GetByEmail)} - " + _errorLoc["DbError-GET"])
                    .LogResponse(_logService) as SingleResponse<UserDto>;

            entity.DeleteDate = DateTime.Now;

            var dichargedEntity = _usersRepository.Update(entity);

            return dichargedEntity != null ?
                new SingleResponse<UserDto>(_usersMapper.MapToDto(dichargedEntity)) :
                new SingleResponse<UserDto>(-2, $"{nameof(UsersMgmtService)}-{nameof(Delete)} - " + _errorLoc["DbError-DISCHARGE"])
                .LogResponse(_logService) as SingleResponse<UserDto>;
        }

        public SingleResponse<FullUserDto> GetFullUser(string userEmail)
        {
            var entity = _usersRepository.GetByEmail(userEmail);

            return entity != null ?
                new SingleResponse<FullUserDto>(_usersMapper.MapToFullUser(entity)) :
                new SingleResponse<FullUserDto>(-1, $"{nameof(UsersMgmtService)}-{nameof(_usersRepository.GetByEmail)} - " + _errorLoc["DbError-GET"]);
        }

        public SingleResponse<GameUserDto> GetGameUser(string nickName)
        {
            var entity = _usersRepository.GetByNickname(nickName);

            return entity != null ?
                new SingleResponse<GameUserDto>(_usersMapper.MapToGameUser(entity)) :
                new SingleResponse<GameUserDto>(-1, $"{nameof(UsersMgmtService)}-{nameof(_usersRepository.GetByEmail)} - " + _errorLoc["DbError-GET"]);
        }

        //Get para Grid
        // Grid llama a detail (FullUser)
        public CollectionResponse<BasicUserDto> GetByFilter(UsersQueryFilter filter)
        {
            throw new NotImplementedException();
        }

        public SingleResponse<LoginResponse> GameSignUp(GameSignUpRequest req)
        {
            //Validate userName && email
            // authService.HashPass
            // repo.insert
            // login = authService.Login(req.Username) <<- si el insert tiene char añade un rol u otro y login ya devuelve el token con el rol (que en este caso deberia ser player)
            // return new SingleResponse<LoginResponse>(login)
            throw new NotImplementedException();
        }

        public BaseResponse UpdateUserLoginStatus(string userNickname, bool bStatus, string currentToken)
        {
            var entity = _usersRepository.GetByNickname(userNickname);

            if (entity == null)
                return new BaseResponse(-1, $"{nameof(UsersMgmtService)}-{nameof(GetByNickName)} - " + _errorLoc["DbError-GET"])
                        .LogResponse(_logService);

            entity.IsLogged = bStatus;
            entity.LastConnectionDate = DateTime.Now;
            //entity.CurrentToken = bStatus == true && !string.IsNullOrEmpty(currentToken) ? currentTokent : "";

            return _usersRepository.Update(entity) != null ? new BaseResponse() :
                new BaseResponse(-1, $"{nameof(UsersMgmtService)}-{nameof(GetByNickName)} - " + _errorLoc["DbError-UPDATE"]);
        }
    }
}
