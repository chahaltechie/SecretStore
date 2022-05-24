using System.Threading.Tasks;
using Application.User.Commands;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecretStore.API.Models.User;

namespace SecretStore.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UserController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserRequest createUserRequest)
        {
            var result = await _mediator.Send(_mapper.Map<CreateUserCommand>(createUserRequest));
            return new OkObjectResult(_mapper.Map<CreateUserResponse>(result));
        }
    }
}