using Application.Secret.Commands.CreateSecret;
using Application.Secret.Models;
using AutoMapper;

namespace Application.Secret.MapperProfile
{
    public class SecretMappingProfile : Profile
    {
        public SecretMappingProfile()
        {
            CreateMap<SecretDto, Domain.Entities.Secret>();
            CreateMap<Domain.Entities.Secret, SecretDto>();
            CreateMap<SecretDto, CreateSecretCommand>();
            CreateMap<CreateSecretCommand, Domain.Entities.Secret>();
        }
    }
}