using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.User.Models;
using AutoMapper;
using MediatR;

namespace Application.User.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand,CreateUserResponseDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<CreateUserResponseDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<Domain.Entities.User>(request);
            await _userRepository.AddItemAsync(user);
            var result = new CreateUserResponseDto
            {
                Id = user.Id,
                Name = user.Name
            };
            return result;
        }
    }
}