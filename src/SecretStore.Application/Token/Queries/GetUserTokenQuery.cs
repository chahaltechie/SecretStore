using MediatR;

namespace Application.Token.Queries
{
    public class GetUserTokenQuery : IRequest<Domain.Models.Token>
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public GetUserTokenQuery()
        {
            
        }
    }
}