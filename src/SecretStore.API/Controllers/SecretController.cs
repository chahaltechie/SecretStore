using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SecretStore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SecretController : ControllerBase
    {
        private readonly ISecretRepository _secretRepository;
        private readonly ILoggerAdapter<SecretController> _loggerAdapter;

        public SecretController(ILogger<SecretController> logger, ISecretRepository secretRepository, ILoggerAdapter<SecretController> loggerAdapter)
        {
            _secretRepository = secretRepository;
            _loggerAdapter = loggerAdapter;
        }
        
        [Authorize]
        [HttpGet]
        public IEnumerable<Secret> Get()
        {
            return new List<Secret>();  
        }
        
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            _loggerAdapter.LogInformation("secret method call started");
            Secret secret = new Secret
            {
                Description = "test",
                Id = "1",
                Importance = Importance.High,
                Title = "Test",
                Items = new List<SecretItem>
                {
                    new SecretItem
                    {
                        Name = "Test Item",
                        Value = "Test Value"
                    }
                }
            };
            await _secretRepository.AddItemAsync(secret);
            _loggerAdapter.LogInformation("secret method call ended");
            return new OkResult();
        }
    }
}