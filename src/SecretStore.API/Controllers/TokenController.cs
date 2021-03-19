using System.Threading.Tasks;
using Application.Secret.Queries;
using Application.Token.Queries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SecretStore.API.Models.Token;

namespace SecretStore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public TokenController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }   

        // GET
        [HttpPost("/Login")]
        public async Task<IActionResult> Login([FromBody] UserTokenReq userTokenReq)
        {
            var result = await _mediator.Send(_mapper.Map<GetUserTokenQuery>(userTokenReq));
            return new OkObjectResult(result);  
        }
    }
}