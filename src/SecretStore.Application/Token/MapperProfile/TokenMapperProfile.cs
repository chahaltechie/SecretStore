using Application.Token.Models;
using AutoMapper;

namespace Application.Token.MapperProfile
{
    public class TokenMapperProfile : Profile
    {
        public TokenMapperProfile()
        {
            CreateMap<Domain.Models.Token, UserTokenResponseDto>();
        }
    }
}