using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Authorization.Interfaces;
using Application.Authorization.Models;
using FluentValidation;
using MediatR;

namespace Application.Common.Behaviours
{
    public class AuthorizationBehaviour<TRequest,TResponse> : IPipelineBehavior<TRequest,TResponse> 
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IAuthorizer<TRequest>> _authorizer;

        public AuthorizationBehaviour(IEnumerable<IAuthorizer<TRequest>> authorizer)
        {
            _authorizer = authorizer;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (_authorizer.Any())
            {
                var result = await _authorizer.FirstOrDefault().AuthorizeAsync(request);
                if (result.IsSuccess) return await next();
                else
                {
                    throw new ValidationException("Invalid user.");
                }
            }
            return await next();
        }
    }
}   