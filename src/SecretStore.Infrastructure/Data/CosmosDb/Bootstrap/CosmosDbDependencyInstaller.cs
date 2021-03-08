using System.Collections.Generic;
using Infrastructure.Data.CosmosDb.Configuration;
using Infrastructure.Data.CosmosDb.Interfaces;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Data.CosmosDb.Bootstrap
{
    public static class CosmosDbDependencyInstaller
    {
        public static IServiceCollection AddCosmosDb(this IServiceCollection collection, string endpointUrl,
            string primaryKey,
            string databaseName, List<ContainerInfo> containers)
        {
            var cosmosClient = new CosmosClient(endpointUrl, primaryKey);
            var cosmosDbContainerFactory = new CosmosDbContainerFactory(cosmosClient, databaseName, containers);

            collection.AddSingleton<ICosmosDbContainerFactory>(cosmosDbContainerFactory);
            return collection;
        }
    }
}