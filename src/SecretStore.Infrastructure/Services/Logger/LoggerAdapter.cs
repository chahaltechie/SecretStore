using System;
using Application.Common.Interfaces;
using Serilog;

namespace Infrastructure.Services.Logger
{
    public class LoggerAdapter<T> : ILoggerAdapter<T>
    {
        private readonly ILogger _logger;

        public LoggerAdapter(ILogger logger)
        {
            _logger = logger;
        }

       
        public void LogError(Exception ex, string message, params object[] args)
        {
            _logger.Error(ex, message, args);
        }
 
        public void LogInformation(string message)
        {
            _logger.Information(message);
        }
    }
}