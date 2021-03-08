using System;
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
    }
}