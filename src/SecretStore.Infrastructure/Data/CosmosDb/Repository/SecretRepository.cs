using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Data.CosmosDb.Interfaces;
using Microsoft.Azure.Cosmos;

namespace Infrastructure.Data.CosmosDb.Repository
{
    public class SecretRepository : CosmosDbRepository<Secret>, ISecretRepository
    {
        public override string ContainerName { get; } = "Secret";
        public override string GenerateId(Secret entity) => Guid.NewGuid().ToString();
        public override PartitionKey ResolvePartitionKey() => new PartitionKey("secret");

        public SecretRepository(ICosmosDbContainerFactory containerFactory) : base(containerFactory)
        {
        }

        public async Task<IEnumerable<Secret>> GetAllSecretsAsync()
        {
            //var results = new List<Secret>();
            string query = @$"SELECT * FROM c ";

            var results = await this.GetItemsAsync(query);

            return results;
        }
    }
}