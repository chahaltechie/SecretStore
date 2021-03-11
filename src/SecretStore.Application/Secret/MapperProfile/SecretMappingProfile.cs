using Application.Common.Models;
using Application.Secret.Commands.CreateSecret;
using AutoMapper;

namespace Application.Secret.MapperProfile
{
    public class SecretMappingProfile : Profile
    {
        public SecretMappingProfile()
        {
            CreateMap<SecretDto, Domain.Entities.Secret>();
            CreateMap<Domain.Entities.Secret, SecretDto>();
            CreateMap<CreateSecretCommand, Domain.Entities.Secret>();
        }
    }
}