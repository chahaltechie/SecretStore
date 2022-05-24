using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SecretStore.API.Configurations;

namespace SecretStore.API.Installers.APIInstallers
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
                    // options.Audience = aadSettings.ResourceId;
                    // options.Authority = $"{aadSettings.Instance}{aadSettings.TenantId}";
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey =
                            new SymmetricSecurityKey(Encoding.ASCII.GetBytes("ThisIsASecretKeyWhichNoOneCanHack")),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        RequireExpirationTime = false,
                        ValidateLifetime = true
                    };
                });
            
        }
    }
}