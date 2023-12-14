using Microsoft.Extensions.Localization;
using PraiseAPI.Domain.DTOs;
using PraiseAPI.Domain.DTOs.ResponseModels.Extensions;
using PraiseAPI.Domain.Entities;
using PraiseAPI.Domain.Mappers;
using PraiseAPI.Domain.Repositories;
using PraiseAPI.Domain.Services;
using PraiseAPI.Infrastructure.Repositories;
using PraiseAPI.Infrastructure.Utilities.ResponseModels;
using PraiseAPI.Resources;

namespace PraiseAPI.Services
{
    public class RolesMgmtService : IRolesMgmtService
    {
        private readonly IRolesRepository _rolesRepository;
        private readonly IUserRolesRepository _userRolesRepository;
        private readonly IUsersRepository _usersRepository;
        private readonly IRolesMapperService _rolesMapper;
        private readonly IApiLogService _logService;
        private readonly IStringLocalizer<ErrorMsg> _errorLoc;

        public RolesMgmtService(IRolesRepository rolesRepo, IUserRolesRepository userRolesRepo, IRolesMapperService rolesMapper, IUsersRepository usersRepo,
            IApiLogService apiLog, IStringLocalizer<ErrorMsg> errorLoc) 
        {
            _rolesRepository = rolesRepo;
            _usersRepository = usersRepo;
            _userRolesRepository = userRolesRepo;
            _rolesMapper = rolesMapper;
            _logService = apiLog;
            _errorLoc = errorLoc;
        }

        public SingleResponse<RoleDto> GetRole(int roleId)
        {
            var entity = _rolesRepository.GetById(roleId);

            return entity != null ? 
                new SingleResponse<RoleDto>(_rolesMapper.MapToDto(entity)) :
                new SingleResponse<RoleDto>(-1, $"{nameof(RolesMgmtService)}-{nameof(GetRole)} - " + _errorLoc["DbError-GET"])
                    .LogResponse(_logService) as SingleResponse<RoleDto>;
            // return new SingleResponse<RoleDto>()
        }

        public SingleResponse<RoleDto> GetRole(string name)
        {
            var entity = _rolesRepository.GetByName(name);

            return entity != null ?
                new SingleResponse<RoleDto>(_rolesMapper.MapToDto(entity)) :
                new SingleResponse<RoleDto>(-1, $"{nameof(RolesMgmtService)}-{nameof(GetRole)} - " + _errorLoc["DbError-GET"])
                    .LogResponse(_logService) as SingleResponse<RoleDto>;
        }

        public CollectionResponse<RoleDto> GetRoles()
        {
            var entities = _rolesRepository.GetAll();

            return entities.Count() > 0 != null ?
                new CollectionResponse<RoleDto>(_rolesMapper.MapManyToDto(entities)) :
                new CollectionResponse<RoleDto>(-1, $"{nameof(RolesMgmtService)}-{nameof(GetRoles)} - " + _errorLoc["DbError-GET"])
                    .LogResponse(_logService) as CollectionResponse<RoleDto>;
        }

        public SingleResponse<RoleDto> AddRole(RoleDto roleDto)
        {
            var entity = _rolesMapper.MapToEntity(roleDto);

            if (string.IsNullOrEmpty(entity.DisplayName))
                entity.DisplayName = entity.Name;

            entity.CreationDate = DateTime.Now;
            entity.Name = entity.Name.ToLower();

            if (entity.Name.Contains(" "))
                return new SingleResponse<RoleDto>(-1, $"{nameof(RolesMgmtService)}-{nameof(AddRole)} - " + "El nombre del rol no puede contener espacios en blanco");

            ApiError error = new ApiError();
            if (!_rolesRepository.CanAdd(entity, out error))
                return new SingleResponse<RoleDto>(-1, error.Msg)
                    .LogResponse(_logService) as SingleResponse<RoleDto>;


            var newEntity = _rolesRepository.Post(entity);

            return newEntity != null ?
                new SingleResponse<RoleDto>(_rolesMapper.MapToDto(newEntity)) :
                new SingleResponse<RoleDto>(-1, $"{nameof(RolesMgmtService)}-{nameof(AddRole)} - " + _errorLoc["DbError-INSERT"])
                    .LogResponse(_logService) as SingleResponse<RoleDto>;
        }

        public SingleResponse<RoleDto> UpdateRole(RoleDto roleDto)
        {
            if (string.IsNullOrEmpty(roleDto.Name))
                return new SingleResponse<RoleDto>(-1, $"{nameof(RolesMgmtService)}-{nameof(UpdateRole)} - " + "Debe proporcionarse un nombre de rol para poder actualizar uno");

            var entity = _rolesRepository.GetByName(roleDto.Name);

            if (entity == null)
                return new SingleResponse<RoleDto>(-1, $"{nameof(RolesMgmtService)}-{nameof(UpdateRole)} - " + _errorLoc["DbError-GET"]);

            entity.DisplayName = roleDto.DisplayName;
            entity.Description = roleDto.Description;
            entity.IsPublic = roleDto.IsPublic;

            var update = _rolesRepository.Update(entity);

            return update != null ?
                new SingleResponse<RoleDto>(_rolesMapper.MapToDto(entity)) :
                new SingleResponse<RoleDto>(-1, $"{nameof(RolesMgmtService)}-{nameof(UpdateRole)} - " + _errorLoc["DbError-UPDATE"]);
        }

        public SingleResponse<RoleDto> DeleteRole(string roleName)
        {
            var entity = _rolesRepository.GetByName(roleName);

            if (entity == null)
                return new SingleResponse<RoleDto>(-1, $"{nameof(RolesMgmtService)}-{nameof(DeleteRole)} - " + _errorLoc["DbError-GET"]);

            var delete = _rolesRepository.Delete(entity);

            return delete != null ?
                new SingleResponse<RoleDto>(_rolesMapper.MapToDto(delete)) :
                new SingleResponse<RoleDto>(-1, $"{nameof(RolesMgmtService)}-{nameof(DeleteRole)} - " + _errorLoc["DbError-DELETE"]);
        }

        public SingleResponse<RoleDto> AddUserRole(int userId, int roleId)
        {
            if (!_rolesRepository.DbSet.Any(x => x.Id == roleId))
                return new SingleResponse<RoleDto>(-1, $"{nameof(RolesMgmtService)}-{nameof(DeleteRole)} - " + "No existe el rol solicitado en DB");

            var insert = new UserRole(userId, roleId);

            var error = new ApiError();
            if (!_userRolesRepository.CanAdd(insert, out error))
                return new SingleResponse<RoleDto>(-1, error.Msg)
                    .LogResponse(_logService) as SingleResponse<RoleDto>;

            var result = _userRolesRepository.Post(insert);

            return insert != null ?
                new SingleResponse<RoleDto>(_rolesMapper.MapToDto(result.Role)) :
                new SingleResponse<RoleDto>(-1, $"{nameof(RolesMgmtService)}-{nameof(AddUserRole)} - " + _errorLoc["DbError-POST"]);
        }

        public CollectionResponse<RoleDto> GetUserRoles(string userName)
        {
            var user = _usersRepository.GetByNickname(userName);

            if (user == null)
                return new CollectionResponse<RoleDto>(-1, $"{nameof(UsersRepository)}-{nameof(_usersRepository.GetByNickname)} - " + _errorLoc["DbError-GET"]);

            return GetUserRoles(user.Id);
        }

        public CollectionResponse<RoleDto> GetUserRoles(int userId)
        {
            var userRoles = _userRolesRepository.GetUserRoles(userId);

            return userRoles.Count() > 0 ?
                new CollectionResponse<RoleDto>(_rolesMapper.MapManyToDto(userRoles.Select(x => x.Role).AsEnumerable())) :
                new CollectionResponse<RoleDto>(-1, $"{nameof(RolesMgmtService)}-{nameof(AddUserRole)} - " + "El usuario no tiene roles asignados");
        }

        public SingleResponse<RoleDto> RemoveUserRole(int userId, int roleId)
        {
            if (!_userRolesRepository.HasRoleAssigned(userId, roleId))
                return new SingleResponse<RoleDto>(-1, $"{nameof(RolesMgmtService)}-{nameof(RemoveUserRole)} - " + " No existe ninguna asignacion para el rol y usuario solicitado");

            var userRole = _userRolesRepository.GetUserRole(userId, roleId);

            var delete = _userRolesRepository.Delete(userRole);

            return delete != null ?
                new SingleResponse<RoleDto>(_rolesMapper.MapToDto(_rolesRepository.GetById(roleId))) :
                new SingleResponse<RoleDto>(-1, $"{nameof(RolesMgmtService)}-{nameof(RemoveUserRole)} - " + _errorLoc["DbError-POST"]);
        }

        public SingleResponse<RoleDto> AddUserRole(string userName, string roleName)
        {
            var user = _usersRepository.GetByNickname(userName);

            if (user == null)
                return new SingleResponse<RoleDto>(-1, $"{nameof(UsersRepository)}-{nameof(_usersRepository.GetByNickname)} - " + _errorLoc["DbError-GET"]);

            var role = _rolesRepository.GetByName(roleName);

            if (role == null)
                return new SingleResponse<RoleDto>(-1, $"{nameof(RolesRepository)}-{nameof(_rolesRepository.GetByName)} - " + _errorLoc["DbError-GET"]);

            return AddUserRole(user.Id, role.Id);
        }

        public SingleResponse<RoleDto> RemoveUserRole(string userName, string roleName)
        {
            var user = _usersRepository.GetByNickname(userName);

            if (user == null)
                return new SingleResponse<RoleDto>(-1, $"{nameof(UsersRepository)}-{nameof(_usersRepository.GetByNickname)} - " + _errorLoc["DbError-GET"]);

            var role = _rolesRepository.GetByName(roleName);

            if (role == null)
                return new SingleResponse<RoleDto>(-1, $"{nameof(RolesRepository)}-{nameof(_rolesRepository.GetByName)} - " + _errorLoc["DbError-GET"]);

            return RemoveUserRole(user.Id, role.Id);
        }

    }
}
