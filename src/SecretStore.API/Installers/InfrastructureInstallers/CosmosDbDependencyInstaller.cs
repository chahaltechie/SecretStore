using Application.Common.Interfaces;
using Infrastructure.Data.CosmosDb.Bootstrap;
using Infrastructure.Data.CosmosDb.Configuration;
using Infrastructure.Data.CosmosDb.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SecretStore.API.Installers.InfrastructureInstallers
{
    public class CosmosDbDependencyInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            var settings = new CosmosDbSettings();
            configuration.Bind(nameof(CosmosDbSettings),settings);
            services.AddCosmosDb(settings.EndPointUrl, settings.PrimaryKey, settings.DatabaseName, settings.Containers);
            services.AddScoped<ISecretRepository, SecretRepository>();
        }
    }
}