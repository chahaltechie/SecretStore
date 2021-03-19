using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Common;
using Infrastructure.Data.CosmosDb.Interfaces;
using Microsoft.Azure.Cosmos;

namespace Infrastructure.Data.CosmosDb.Repository
{
    public abstract class CosmosDbRepository<T> : IRepository<T>, IContainerContext<T> where T : BaseEntity
    {
        private readonly Container _container;

        protected CosmosDbRepository(ICosmosDbContainerFactory containerFactory)
        {
            _container = containerFactory.GetContainer(ContainerName)._container;
        }
        public async Task<IEnumerable<T>> GetItemsAsync(string query)
        {
            FeedIterator<T> resultSetIterator = _container.GetItemQueryIterator<T>(new QueryDefinition(query));
            List<T> results = new List<T>();
            while (resultSetIterator.HasMoreResults)
            {
                FeedResponse<T> response = await resultSetIterator.ReadNextAsync();

                results.AddRange(response.ToList());
            }

            return results;
        }
       
        public async Task<T> GetItemAsync(string id)
        {
            try
            {
                ItemResponse<T> response = await _container.ReadItemAsync<T>(id,ResolvePartitionKey());
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task AddItemAsync(T item)
        {
            item.PartitionKey = ResolveStringPartitionKey();
            item.Id = GenerateId(item);
            await _container.CreateItemAsync<T>(item);
        }

        public async Task UpdateItemAsync(string id, T item)
        {
            await _container.UpsertItemAsync(item, ResolvePartitionKey());
        }

        public async Task DeleteItemAsync(string id)
        {
            await _container.DeleteItemAsync<T>(id, ResolvePartitionKey());
        }

        public abstract string ContainerName { get; }
        public abstract string GenerateId(T entity);
        public abstract PartitionKey ResolvePartitionKey();
        public abstract string ResolveStringPartitionKey();
        public abstract string ResolveUniqueKey(T entity);
    }
}