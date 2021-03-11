using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Secret.Commands.CreateSecret;
using Application.Secret.Queries;
using Domain.Entities;
using Domain.Enums;
using MediatR;
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
        private readonly IMediator _mediator;
        
        public SecretController(ILogger<SecretController> logger, ISecretRepository secretRepository, ILoggerAdapter<SecretController> loggerAdapter, IMediator mediator)
        {
            _secretRepository = secretRepository;
            _loggerAdapter = loggerAdapter;
            _mediator = mediator;
        }
        
        [Authorize]
        [HttpGet]
        public IEnumerable<Secret> Get()
        {
            return new List<Secret>();  
        }
        
        [HttpGet("/AllSecrets")]
        public async Task<IActionResult> GetAllSecrets()
        {
            var query = new GetAllSecretsQuery();
            var result = await _mediator.Send(query);
            return new OkObjectResult(result);
        }
        
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateSecretCommand secretCommand)
        {
            _loggerAdapter.LogInformation("secret method call started");
            var result = await _mediator.Send(secretCommand);
            _loggerAdapter.LogInformation("secret method call ended");
            return new OkObjectResult(result);
        }
    }
}