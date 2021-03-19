using Application.Authorization.Interfaces;
using Application.Common.Interfaces;
using Application.Token.Interfaces;
using Infrastructure.Data.CosmosDb.Bootstrap;
using Infrastructure.Data.CosmosDb.Configuration;
using Infrastructure.Data.CosmosDb.Repository;
using Infrastructure.Identity;
using Infrastructure.Services;
using Infrastructure.Services.Logger;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var settings = new CosmosDbSettings();
            configuration.Bind(nameof(CosmosDbSettings),settings);
            services.AddCosmosDb(settings.EndPointUrl, settings.PrimaryKey, settings.DatabaseName, settings.Containers);
            services.AddScoped<ISecretRepository, SecretRepository>();
            
            //logger
            services.AddLogger(configuration);
            
            //Repository
            services.AddScoped<ISecretRepository, SecretRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<ITokenGenerator, TokenGenerator>();
            services.AddTransient<IUserValidator<ApplicationUserContext>, UserValidator>();
            
            return services;
        }
    }
}