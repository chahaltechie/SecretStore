

using Microsoft.Azure.Cosmos;

namespace Infrastructure.Data.CosmosDb.Interfaces
{
    public interface ICosmosDbContainer
    {
        Container _container { get; }
    }
}