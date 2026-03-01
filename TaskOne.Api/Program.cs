using TaskOne.Api.Extensions;
using TaskOne.Application;
using TaskOne.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApiServices()
    .AddApplication()
    .AddInfrastructurs(builder.Configuration)
    .AddAuthenticationService(builder.Configuration)
    .AddSwaggerService();

var app = builder.Build();

app.UseCustomMiddlewares();

app.UseSwaggerPipeline();

app.MapEndpoints();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();