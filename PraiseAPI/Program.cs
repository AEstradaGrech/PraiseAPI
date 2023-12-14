using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PraiseAPI;
using PraiseAPI.Infrastructure.Context;
using PraiseAPI.Infrastructure.Utilities;
using Serilog;

/*
 * https://github.com/datalust/dotnet6-serilog-example?ref=blog.datalust.co
 * 
 CreateBootstrapLogger() sets up Serilog so that the initial logger configuration (which writes only to Console), 
 can be swapped out later in the initialization process, once the web hosting infrastructure is available.
 */

Log.Logger = new LoggerConfiguration()
    .WriteTo
    .Console()
    .CreateBootstrapLogger();

Log.Information("App init ...");

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((ctx, logConfig) => logConfig.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration));
    // CHECK --> builder.Services.AddMvc()

    builder.Services.AddControllers(options => options.Filters.Add<EndpointExecutionFilter>());
    builder.Services.AddLocalization();
    builder.Services.AddDbContext<PraiseDbContext>(options => options.UseSqlServer(builder.Configuration["ConnectionString"]))
                    .AddConfigurations(builder.Configuration)
                    .ConfigureServices()
                    .ConfigureTokenAuthentication(builder.Configuration)
                    .AddCorsPolicy()
                    .AddAuthorizationPolicies();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseSerilogRequestLogging();

    app.Configure()
       .UseHttpsRedirection()
       .UseAuthentication()
       .UseAuthorization();

    app.MapControllers();

    app.Run();

}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down complete...");
    Log.CloseAndFlush();
}

