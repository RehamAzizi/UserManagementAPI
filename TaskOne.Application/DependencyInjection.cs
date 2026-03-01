using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using TaskOne.Application.Features.Authentication.Commands;
using TaskOne.Application.Features.Authentication.Queries;

namespace TaskOne.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                //configuration.RegisterServicesFromAssembly(typeof(Program).Assembly);
                configuration.RegisterServicesFromAssembly(typeof(RegisterCommandHandler).Assembly);
                configuration.RegisterServicesFromAssembly(typeof(LoginQueryHandler).Assembly);
            });
            services.AddValidatorsFromAssemblyContaining<LogInRequestValidator>();
            services.AddValidatorsFromAssemblyContaining<RegisterRequestValidator>();

            return services;
        }
    }
}