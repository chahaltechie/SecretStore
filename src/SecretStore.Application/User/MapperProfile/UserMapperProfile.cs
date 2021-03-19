using Application.User.Commands;
using AutoMapper;

namespace Application.User.MapperProfile
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<CreateUserCommand, Domain.Entities.User>()
                .ForPath(dest => dest.Role.Name, act => act.MapFrom(src => src.Role));
        }
    }
}