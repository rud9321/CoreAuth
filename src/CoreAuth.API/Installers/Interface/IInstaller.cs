using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoreAuth.API.Installers
{
    public interface IInstaller
    {
        void InsallServices(IServiceCollection services, IConfiguration configuration);
    }
}