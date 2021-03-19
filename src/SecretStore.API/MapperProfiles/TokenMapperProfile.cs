using Application.Token.Models;
using Application.Token.Queries;
using AutoMapper;
using SecretStore.API.Models.Token;

namespace SecretStore.API.MapperProfiles
{
    public class TokenMapperProfile : Profile
    {
        public TokenMapperProfile()
        {
            CreateMap<UserTokenReq, GetUserTokenQuery>();
            CreateMap<UserTokenResponseDto, UserTokenResponse>();
        }
    }
}