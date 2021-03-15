using System.Threading.Tasks;
using Application.Authorization.Models;
using MediatR;

namespace Application.Authorization.Interfaces
{
    public interface IAuthorizer<TRequest>
    {
        Task<AuthorizationResponse> AuthorizeAsync(TRequest instance);
    }
}