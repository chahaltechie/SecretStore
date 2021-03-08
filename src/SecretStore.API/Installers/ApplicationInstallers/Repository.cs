using Application.Common.Interfaces;
using Infrastructure.Data.CosmosDb.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SecretStore.API.Installers.ApplicationInstallers
{
    public class Repository : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ISecretRepository, SecretRepository>();
        }
    }
}