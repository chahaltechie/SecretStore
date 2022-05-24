using System.Reflection;
using Application.Authorization.Authorizers;
using Application.Authorization.Interfaces;
using Application.Common.Behaviours;
using Application.Common.Interfaces;
using Application.Secret.Commands.CreateSecret;
using Application.Secret.Queries;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient<IAuthorizer<GetAllSecretsQuery>, GetSecretQueryAuthorizer>();
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}