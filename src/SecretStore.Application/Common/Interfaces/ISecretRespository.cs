using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface ISecretRepository : IRepository<Domain.Entities.Secret>
    {
        Task<IEnumerable<Domain.Entities.Secret>> GetAllSecretsAsync();
    }
}   