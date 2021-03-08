using System.Threading.Tasks;

namespace Infrastructure.Data.CosmosDb.Interfaces
{
    public interface ICosmosDbContainerFactory
    {
        ICosmosDbContainer GetContainer(string containerName);

        Task EnsureDbSetupAsync();
    }

    
    
}