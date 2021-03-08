using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data.CosmosDb.Configuration;
using Infrastructure.Data.CosmosDb.Interfaces;
using Microsoft.Azure.Cosmos;

namespace Infrastructure.Data.CosmosDb
{
    public class CosmosDbContainerFactory : ICosmosDbContainerFactory
    {
        private readonly CosmosClient _cosmosClient;
        private readonly string _databaseName;
        private readonly List<ContainerInfo> _containers;

        public CosmosDbContainerFactory(CosmosClient cosmosClient, string databaseName, List<ContainerInfo> containers)
        {
            _cosmosClient = cosmosClient;
            _databaseName = databaseName;
            _containers = containers;
        }

        public ICosmosDbContainer GetContainer(string containerName)
        {
            if (_containers.Any(x => x.Name == containerName))
            {
                return new CosmosDbContainer(_cosmosClient, _databaseName, containerName);
            }
            // throw custom exception here
            throw new Exception("Container does not exist");
        }

        public async Task EnsureDbSetupAsync()
        {
            var database = await _cosmosClient.CreateDatabaseIfNotExistsAsync(_databaseName);

            foreach (ContainerInfo container in _containers)
            {
                await database.Database.CreateContainerIfNotExistsAsync(container.Name, $"{container.PartitionKey}");
            }
        }
    }

    
}