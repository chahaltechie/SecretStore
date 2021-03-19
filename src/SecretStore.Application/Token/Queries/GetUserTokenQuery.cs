using Application.Token.Models;
using MediatR;

namespace Application.Token.Queries
{
    public class GetUserTokenQuery : IRequest<UserTokenResponseDto>
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public GetUserTokenQuery()
        {
            
        }
    }
}