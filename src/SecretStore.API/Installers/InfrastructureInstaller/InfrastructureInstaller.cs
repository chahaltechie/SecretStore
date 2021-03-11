using Application.Common.Interfaces;
using Infrastructure;
using Infrastructure.Data.CosmosDb.Bootstrap;
using Infrastructure.Data.CosmosDb.Configuration;
using Infrastructure.Data.CosmosDb.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SecretStore.API.Installers.InfrastructureInstallers
{
    public class InfrastructureInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddInfrastructure(configuration);
        }
    }
}