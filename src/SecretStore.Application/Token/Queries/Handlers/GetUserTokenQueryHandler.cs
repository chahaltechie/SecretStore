using System.Threading;
using System.Threading.Tasks;
using Application.Token.Interfaces;
using Application.Token.Models;
using AutoMapper;
using MediatR;

namespace Application.Token.Queries.Handlers
{
    public class GetUserTokenQueryHandler : IRequestHandler<GetUserTokenQuery,UserTokenResponseDto>
    {
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IMapper _mapper;

        public GetUserTokenQueryHandler(ITokenGenerator tokenGenerator, IMapper mapper)
        {
            _tokenGenerator = tokenGenerator;
            _mapper = mapper;
        }
        public async Task<UserTokenResponseDto> Handle(GetUserTokenQuery request, CancellationToken cancellationToken)
        {
            var token = await _tokenGenerator.GenerateTokenAsync(request.UserName, request.Password);
            var result = _mapper.Map<UserTokenResponseDto>(token);
            return result;
        }
    }
}