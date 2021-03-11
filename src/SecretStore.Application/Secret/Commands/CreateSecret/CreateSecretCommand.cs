using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Secret.Models;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Secret.Commands.CreateSecret
{
    public class CreateSecretCommand : IRequest<SecretResponse>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Importance Importance { get; set; }
        public List<SecretItem> Items { get; set; }
    }

    public class CreateSecretCommandHandler : IRequestHandler<CreateSecretCommand, SecretResponse>
    {
        private readonly ISecretRepository _secretRepository;
        private readonly IMapper _mapper;

        public CreateSecretCommandHandler(ISecretRepository secretRepository, IMapper mapper)
        {
            _secretRepository = secretRepository;
            _mapper = mapper;
        }

        public async Task<SecretResponse> Handle(CreateSecretCommand request, CancellationToken cancellationToken)
        {
            var secret = _mapper.Map<Domain.Entities.Secret>(request);
            await _secretRepository.AddItemAsync(secret);
            return new SecretResponse
            {
                Id = secret.Id,
                Name = secret.Title
            };
        }
    }
    
    
}