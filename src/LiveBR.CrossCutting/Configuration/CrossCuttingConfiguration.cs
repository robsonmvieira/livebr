using LiveBR.CrossCutting.Utils.EncoderPassword;
using Microsoft.Extensions.DependencyInjection;

namespace LiveBR.CrossCutting.Configuration
{
    public static class CrossCuttingConfiguration
    {
        public static void AddCrossCuttingDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IEncoderPassword, EncoderPassword>();
        }
    }
}