using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PraiseAPI.Domain.DTOs;
using PraiseAPI.Domain.DTOs.RequestModels.Filters;
using PraiseAPI.Domain.Services;
using System.Net;

namespace PraiseAPI.Controllers
{
    [Route("api/user-roles")]
    [ApiController]
    //[Authorize("Management")]
    public class UserRolesController : BaseController
    {
        private readonly IRolesMgmtService _rolesMgmtService;

        public UserRolesController(IRolesMgmtService rolesService, IApiLogService apiLog, IHttpContextAccessor ctx) : base(apiLog, ctx)
        {
            _rolesMgmtService = rolesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = _rolesMgmtService.GetRoles();

            if (response != null)
                return response.HasError() ? LogResponse(response.Error) : Ok(response);

            return StatusCode((int)HttpStatusCode.InternalServerError);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = _rolesMgmtService.GetRole(id);

            if (response != null)
                return response.HasError() ? LogResponse(response.Error) : Ok(response);

            return StatusCode((int)HttpStatusCode.InternalServerError);
        }

        [HttpGet("rolename/{roleName}")]
        public async Task<IActionResult> Get(string roleName)
        {
            var response = _rolesMgmtService.GetRole(roleName);

            if (response != null)
                return response.HasError() ? LogResponse(response.Error) : Ok(response);

            return StatusCode((int)HttpStatusCode.InternalServerError);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RoleDto dto)
        {
            var response = _rolesMgmtService.AddRole(dto);

            if (response != null)
                return response.HasError() ? LogResponse(response.Error) : Ok(response);

            return StatusCode((int)HttpStatusCode.InternalServerError);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Put([FromBody] RoleDto dto)
        {
            var response = _rolesMgmtService.UpdateRole(dto);

            if (response != null)
                return response.HasError() ? LogResponse(response.Error) : Ok(response);

            return StatusCode((int)HttpStatusCode.InternalServerError);
        }

        [HttpDelete("delete/{roleName}")]
        public async Task<IActionResult> Delete(string roleName)
        {
            var response = _rolesMgmtService.DeleteRole(roleName);

            if (response != null)
                return response.HasError() ? LogResponse(response.Error) : Ok(response);

            return StatusCode((int)HttpStatusCode.InternalServerError);
        }

        [HttpGet("user/{userName}")]
        public async Task<IActionResult> GetUserRoles(string userName)
        {
            var response = _rolesMgmtService.GetUserRoles(userName);

            if (response != null)
                return response.HasError() ? LogResponse(response.Error) : Ok(response);

            return StatusCode((int)HttpStatusCode.InternalServerError);
        }

        [HttpPost("add-user-role/{userName}/{roleName}")]
        public async Task<IActionResult> AddUserRole(string userName, string roleName)
        {
            var response = _rolesMgmtService.AddUserRole(userName, roleName);

            if (response != null)
                return response.HasError() ? LogResponse(response.Error) : Ok(response);

            return StatusCode((int)HttpStatusCode.InternalServerError);
        }

        [HttpDelete("remove-user-role/{userName}/{roleName}")]
        public async Task<IActionResult> RemoveUserRole(string userName, string roleName)
        {
            var response = _rolesMgmtService.RemoveUserRole(userName, roleName);

            if (response != null)
                return response.HasError() ? LogResponse(response.Error) : Ok(response);

            return StatusCode((int)HttpStatusCode.InternalServerError);
        }

        [HttpPost("filter")]
        public async Task<IActionResult> Filter([FromBody] RolesQueryFilter filter)
        {
            var response = _rolesMgmtService.GetRoles(filter);

            if (response != null)
                return response.HasError() ? LogResponse(response.Error) : Ok(response);

            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }
}
