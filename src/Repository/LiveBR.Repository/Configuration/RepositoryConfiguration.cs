using LiveBR.CrossCutting.Interfaces;
using LiveBR.Domain.Interfaces;
using LiveBR.Repository.Context;
using LiveBR.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LiveBR.Repository.Configuration
{
    public static class RepositoryConfiguration
    {
        public static void AddRepositoryDependencyInjection(this IServiceCollection services, string connection)
        {
            services.AddDbContext<LiveBrContext>(opt =>
            {
                opt.UseSqlServer(connection);
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<LiveBrContext>();
        } 
    }
}