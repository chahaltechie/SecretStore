using Application.Common.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Infrastructure.Services.Logger
{
    public static class ConfigureLogger
    {
        public static IServiceCollection AddLogger(this IServiceCollection collection, IConfiguration config)
        {
            //Initialize Logger
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .CreateLogger();
            collection.AddSingleton(typeof(ILoggerAdapter<>), typeof(LoggerAdapter<>));
            collection.AddSingleton<ILogger>(Log.Logger);
            return collection;
        }
    }
}