using System.Threading;
using System.Threading.Tasks;
using Application.Authorization.Interfaces;
using Application.Authorization.Models;
using MediatR;

namespace Application.Common.Behaviours
{
    public class AuthorizationBehaviour<TRequest,TResponse> : IPipelineBehavior<TRequest,TResponse> 
        where TRequest : IRequest<TResponse>
    {
        private readonly IAuthorizer<TRequest> _authorizer;

        public AuthorizationBehaviour(IAuthorizer<TRequest> authorizer)
        {
            _authorizer = authorizer;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var result = await _authorizer.AuthorizeAsync(request);
            return await next();
        }
    }
}   