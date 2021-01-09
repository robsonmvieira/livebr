
using AutoMapper;
using LiveBR.Application.AutoMapper;
using LiveBR.Application.Services.Implementation;
using LiveBR.CrossCutting.Configuration;
using LiveBR.Domain.Services;
using LiveBR.Repository.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace LiveBR.Application.Configuration
{
    public static class ApiConfiguration
    {
        public static void AddApplicationDependencyInjection(this IServiceCollection services, string connection)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddRepositoryDependencyInjection(connection);
            services.AddCrossCuttingDependencyInjectionConfiguration();

            services.AddAutoMapper(typeof(UserAutoMapper));

        }
    }
}