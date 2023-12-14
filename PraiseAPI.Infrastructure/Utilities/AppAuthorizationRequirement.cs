using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraiseAPI.Infrastructure.Utilities
{
    public class AppAuthorizationRequirement : AuthorizationHandler<AppAuthorizationRequirement>, IAuthorizationRequirement
    {
        public string _validAudience;

        public AppAuthorizationRequirement(string validAudience)
        {
            _validAudience = validAudience;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, AppAuthorizationRequirement requirement)
        {
            if (!context.User.Identities.Any()) return;

            if (!context.User.Identities.First().Claims.Any()) return;

            var tokenAudience = context.User.Identities.First().Claims.Where(c => c.Type == "aud").First();

            if (tokenAudience != null && tokenAudience.Value == _validAudience)
                context.Succeed(requirement);

            return;
        }
    }
}
