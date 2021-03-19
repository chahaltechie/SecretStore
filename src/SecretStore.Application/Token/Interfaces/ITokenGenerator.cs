using System.Threading.Tasks;

namespace Application.Token.Interfaces
{
    public interface ITokenGenerator
    {
        Task<Domain.Models.Token> GenerateTokenAsync(string username, string password);
    }
}