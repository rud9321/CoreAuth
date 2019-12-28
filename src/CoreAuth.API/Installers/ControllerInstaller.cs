using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoreAuth.API.Installers
{
    public class ControllerInstaller : IInstaller
    {
        public void InsallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers().AddNewtonsoftJson();
        }
    }
}