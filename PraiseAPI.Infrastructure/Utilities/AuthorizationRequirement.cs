using Microsoft.AspNetCore.Authorization;

namespace PraiseAPI.Infrastructure.Utilities
{
    public class AuthorizationRequirement : AuthorizationHandler<AuthorizationRequirement>, IAuthorizationRequirement
    {
        private IEnumerable<string> _requiredRoles;

        public AuthorizationRequirement(IEnumerable<string> requiredRoles)
        {
            _requiredRoles = requiredRoles;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, AuthorizationRequirement requirement)
        {
            var roleClaims = context.User.Identities.First().Claims.Where(c => c.Type.Contains("prs_rol"));

            foreach(var claim in roleClaims)
                if (_requiredRoles.Contains(claim.Value))
                    context.Succeed(requirement);

            return;
        }
    }
}
