using SecretStore.API.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SecretStore.API.Installers
{
    public class AuthenticationInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            var aadSettings = configuration.ConfigureAad();
            services.AddSingleton(configuration.ConfigureAad());
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Audience = aadSettings.ResourceId;
                    options.Authority = $"{aadSettings.Instance}{aadSettings.TenantId}";
                });
            
        }
    }
}