using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace SecretStore.API.Installers
{
    public class ControllersInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SecretStore.API", Version = "v1" });
            });
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}   