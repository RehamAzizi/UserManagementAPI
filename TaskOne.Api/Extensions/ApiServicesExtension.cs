namespace TaskOne.Api.Extensions
{
    public static class ApiServicesExtension
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services) 
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();

            return services;
        }
    }
}