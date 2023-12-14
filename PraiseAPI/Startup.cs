using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PraiseAPI.Domain.Services;
using PraiseAPI.Infrastructure.Configs;
using PraiseAPI.Infrastructure.Context;
using PraiseAPI.Infrastructure.Utilities;
using PraiseAPI.Infrastructure.Utilities.ResponseModels;
using PraiseAPI.Services;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace PraiseAPI
{
    public static class Startup
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            var mainAssembly = Assembly.Load(new AssemblyName("PraiseAPI"));
            var infraAssembly = Assembly.Load(new AssemblyName("PraiseAPI.Infrastructure"));
  
            services.AddHttpContextAccessor()
                    .Scan(typeSourceSelector => typeSourceSelector
                        .FromAssemblies(mainAssembly, infraAssembly)
                            .AddClasses()
                            .AsMatchingInterface()
                            .WithScopedLifetime());

            return services;
        }
        
        private static IApplicationBuilder ConfigureGlobalErrorHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        await context.Response.WriteAsync(new ApiError()
                        {
                            ErrorCode = context.Response.StatusCode,
                            Msg = $"Internal Server Error. Exception Message :: {contextFeature.Error}"
                        }.ToString());
                    }
                });
            });

            return app;
        }

        public static IServiceCollection AddCorsPolicy(this IServiceCollection services)
            => services.AddCors(options => {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .SetIsOriginAllowed((host) => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithExposedHeaders("Authorization")
                    .AllowCredentials());
             });

        public static IServiceCollection AddAuthorizationPolicies(this IServiceCollection services)
            => services.AddAuthorization(options => {
                options.SetClientAppPolicy("PraiseGame", "praise-game")
                       .SetClientAppPolicy("PraiseWeb", "praise-web")
                       .SetAppUserPolicy("PraiseGameUser", "praise-game", new List<string> { "user", "player" })
                       .SetCustomPolicy("Anonymous", new List<string> { "anon" })
                       .SetCustomPolicy("Management", new List<string> { "mgmt" , "admin" })
                       .SetCustomPolicy("DefaultUser", new List<string> { "user", "player", "dev", "admin"})
                       .SetCustomPolicy("Admin", new List<string> { "admin" });
            });
        
        public static IApplicationBuilder Configure(this IApplicationBuilder app)
            => app.ConfigureGlobalErrorHandler()
                  .HandleMigrations()
                  .UseCors();
                  
        public static IServiceCollection AddConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoDbConfig>(configuration.GetSection(nameof(MongoDbConfig)));
            services.Configure<AuthConfig>(configuration.GetSection(nameof(AuthConfig)));

            return services;
        }

        public static IServiceCollection ConfigureTokenAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var issuer = configuration.GetSection("AuthConfig")["JwtIssuer"];
            var audience = configuration.GetSection("AuthConfig")["JwtAudience"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("AuthConfig")["JwtKey"]));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = key,
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true
                };
            });

            return services;
        }

        private static IApplicationBuilder HandleMigrations(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

            var ctx = scope.ServiceProvider.GetRequiredService<PraiseDbContext>();

            if(ctx != null)
            {
                if (ctx.Database.GetPendingMigrations().Count() > 0)
                    ctx.Database.Migrate();
            }

            return app;
        }

        private static AuthorizationPolicyBuilder CheckRole(this AuthorizationPolicyBuilder builder, List<string> roleNames) 
            => builder.AddRequirements(new AuthorizationRequirement(roleNames));
        private static AuthorizationPolicyBuilder CheckAudience(this AuthorizationPolicyBuilder builder, string audience)
            => builder.AddRequirements(new AppAuthorizationRequirement(audience));

        private static AuthorizationOptions SetCustomPolicy(this AuthorizationOptions options, string policyName, List<string> policyClaims)
        {
            options.AddPolicy(policyName, policy => policy.CheckRole(policyClaims));
            return options;
        }

        private static AuthorizationOptions SetClientAppPolicy(this AuthorizationOptions options,string policyName, string validAudience)
        {
            options.AddPolicy(policyName, policy => policy.CheckAudience(validAudience));
            return options;
        }

        private static AuthorizationOptions SetAppUserPolicy(this AuthorizationOptions options, string policyName, string validAudience, List<string> policyClaims)
        {
            options.AddPolicy(policyName, policy => 
                policy.CheckAudience(validAudience)
                      .CheckRole(policyClaims));

            return options;
        }

    }
}
