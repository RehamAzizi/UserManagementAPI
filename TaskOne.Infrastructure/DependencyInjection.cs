using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskOne.Application.Abstraction;
using TaskOne.Infrastructure.Authentication;
using TaskOne.Infrastructure.Persistence;
using TaskOne.Infrastructure.Services;

namespace TaskOne.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructurs(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.Configure<JWTSettings>(configuration.GetSection(JWTSettings.SectionName));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            return services;
        }
    }
}