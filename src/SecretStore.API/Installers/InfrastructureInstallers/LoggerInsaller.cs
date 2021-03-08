using Infrastructure.Services.Logger;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SecretStore.API.Installers.InfrastructureInstallers
{
    public class LoggerInsaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddLogger(configuration);
        }
    }
}