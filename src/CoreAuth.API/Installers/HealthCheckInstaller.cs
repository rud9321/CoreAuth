using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoreAuth.API.Installers
{
    public class HealthCheckInstaller : IInstaller
    {
        public void InsallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddDbContextCheck<DataBaseContext>();
        }
    }
}