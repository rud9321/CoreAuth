using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoreAuth.API.Installers
{
    public static class InstallerExtensions
    {        
        public static void InstallServicesInAssembly(this IServiceCollection services, IConfiguration configuration){
            var installers = typeof(Startup).Assembly.ExportedTypes
            .Where(_ => typeof(IInstaller).IsAssignableFrom(_) && !_.IsInterface && !_.IsAbstract)
            .Select(Activator.CreateInstance)
            .Cast<IInstaller>()
            .ToList();

            installers.ForEach(_ => _.InsallServices(services,configuration));
        }
    }
}