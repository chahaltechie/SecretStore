using Application.User.Commands;
using Application.User.Models;
using AutoMapper;
using SecretStore.API.Models.User;

namespace SecretStore.API.MapperProfiles
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<CreateUserRequest, CreateUserCommand>();
            CreateMap<CreateUserResponseDto, CreateUserResponse>();
        }
    }
}