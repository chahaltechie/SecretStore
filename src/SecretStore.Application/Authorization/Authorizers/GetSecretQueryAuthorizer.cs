using System.Threading.Tasks;
using Application.Authorization.Interfaces;
using Application.Authorization.Models;
using Application.Secret.Queries;

namespace Application.Authorization.Authorizers
{
    public class GetSecretQueryAuthorizer : IAuthorizer<GetAllSecretsQuery>
    {
        private readonly IUserContext _userContext;

        public GetSecretQueryAuthorizer(IUserContext userContext)
        {
            _userContext = userContext;
        }

        public async Task<AuthorizationResponse> AuthorizeAsync(GetAllSecretsQuery instance)
        {
            return new AuthorizationResponse();
        }
    }
}