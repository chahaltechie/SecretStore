using System.Threading.Tasks;
using Application.Authorization.Interfaces;
using Domain.Common;

namespace Application.Token.Interfaces
{
    public interface ITokenGenerator
    {
        Task<Domain.Models.Token> GenerateTokenAsync(string username, string password);
    }
}