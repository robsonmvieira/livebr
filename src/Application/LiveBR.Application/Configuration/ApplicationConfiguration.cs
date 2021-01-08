using AutoMapper.Configuration;
using LiveBR.Application.Services.Implementation;
using LiveBR.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LiveBR.Application.Configuration
{
    public static class ApiConfiguration
    {
        public static void AddApplicationDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            
        }
    }
}