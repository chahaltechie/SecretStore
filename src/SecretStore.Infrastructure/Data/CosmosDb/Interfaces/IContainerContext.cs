using Domain.Common;
using Microsoft.Azure.Cosmos;

namespace Infrastructure.Data.CosmosDb.Interfaces
{
    public interface IContainerContext<T> where T : BaseEntity
    {
        string ContainerName { get; }
        string GenerateId(T entity);    
        PartitionKey ResolvePartitionKey();
        string ResolveStringPartitionKey();
        string ResolveUniqueKey(T entity);
        string ResolveDocumentType();
    }
}