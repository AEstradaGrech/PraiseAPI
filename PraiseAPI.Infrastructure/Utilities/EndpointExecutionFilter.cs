using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace PraiseAPI.Infrastructure.Utilities
{
    public class EndpointExecutionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != "localhost")
            {
                if (context.HttpContext.Request.Headers.Keys.Contains("X-Client-Id"))
                {
                    if (string.IsNullOrEmpty(context.HttpContext.Request.Headers["X-Client-Id"]))
                    {
                        context.Result = new StatusCodeResult((int)HttpStatusCode.Unauthorized);
                        return;
                    }
                }
                else
                {
                    context.Result = new StatusCodeResult((int)HttpStatusCode.Unauthorized);
                    return;
                }
            }
           
            await next();
        }
    }
}
