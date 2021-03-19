using System.Threading.Tasks;
using Domain.Common;

namespace Application.Authorization.Interfaces
{
    public interface IUserValidator<T> where T : BaseUserContext
    {
        Task<T> ValidateUser(string username, string password);
    }
}   