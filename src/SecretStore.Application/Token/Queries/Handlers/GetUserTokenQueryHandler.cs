using System.Threading;
using System.Threading.Tasks;
using Application.Token.Interfaces;
using MediatR;

namespace Application.Token.Queries.Handlers
{
    public class GetUserTokenQueryHandler : IRequestHandler<GetUserTokenQuery,Domain.Models.Token>
    {
        private readonly ITokenGenerator _tokenGenerator;

        public GetUserTokenQueryHandler(ITokenGenerator tokenGenerator)
        {
            _tokenGenerator = tokenGenerator;
        }
        public async Task<Domain.Models.Token> Handle(GetUserTokenQuery request, CancellationToken cancellationToken)
        {
            var result = await _tokenGenerator.GenerateTokenAsync(request.UserName, request.Password);
            return result;
        }
    }
}