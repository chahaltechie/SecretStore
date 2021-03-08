using Microsoft.Extensions.Configuration;
using SecretStore.API.Models;

namespace SecretStore.API.Configurations
{
    public static class AadSettings
    {
        public static AAD ConfigureAad(this IConfiguration configuration)
        {
            AAD aadSettings = new();
            configuration.Bind(nameof(AAD),aadSettings);
            return aadSettings;
        }
    }
}