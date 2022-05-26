using Microsoft.Extensions.Configuration;
using SecretStore.API.Models;

namespace SecretStore.API.Configurations
{
    public static class JwtSecuritySettings
    {
        public static JwtSecurity ConfigureJwtSecurity(this IConfiguration configuration)
        {
            JwtSecurity jwtSecurity = new();
            configuration.Bind(nameof(JwtSecurity), jwtSecurity);
            return jwtSecurity;
        }
    }
}