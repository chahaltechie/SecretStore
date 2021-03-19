using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface IUserRepository : IRepository<Domain.Entities.User>
    {
        Task<Domain.Entities.User> GetUserByEmailAsync(string email);
        Task<Domain.Entities.User> GetUserByNameAsync(string name);
    }
}   