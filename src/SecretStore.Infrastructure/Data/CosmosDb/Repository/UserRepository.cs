using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Infrastructure.Data.CosmosDb.Interfaces;
using Microsoft.Azure.Cosmos;
using User = Domain.Entities.User;

namespace Infrastructure.Data.CosmosDb.Repository
{
    public class UserRepository : CosmosDbRepository<User>, IUserRepository
    {
        public UserRepository(ICosmosDbContainerFactory containerFactory) : base(containerFactory)
        {
        }

        public override string ContainerName { get; } = "Account";
        public override string GenerateId(User entity) => Guid.NewGuid().ToString();


        public override PartitionKey ResolvePartitionKey() => new PartitionKey("user");
        public override string ResolveStringPartitionKey() => "user";
        public override string ResolveUniqueKey(User entity) => $"{entity.Name}_{entity.Email}";
        public override string ResolveDocumentType() => "user";

        public async Task<User> GetUserByEmailAsync(string email)
        {
            string query = @$"SELECT * FROM c where c.Email = '${email}'";

            var results = await this.GetItemAsync(query);

            return results;
        }

        public async Task<User> GetUserByNameAsync(string name)
        {
            string query = @$"SELECT * FROM c where c.Name = '{name}' and c.pk = '{ResolveStringPartitionKey()}'";

            var results = await this.GetItemsAsync(query);

            return results?.FirstOrDefault();
        }
    }
}