using Application.User.Models;
using MediatR;

namespace Application.User.Commands
{
    public class CreateUserCommand : IRequest<CreateUserResponseDto>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}