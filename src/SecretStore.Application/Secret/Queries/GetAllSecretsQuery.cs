using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Secret.Models;
using AutoMapper;
using MediatR;

namespace Application.Secret.Queries
{
    public class GetAllSecretsQuery : IRequest<List<SecretDto>>
    {
         
    }
    
    public class GetAllSecretsQueryHandler : IRequestHandler<GetAllSecretsQuery, List<SecretDto>>
    {
        private readonly ISecretRepository _secretRepository;
        private readonly IMapper _mapper;

        public GetAllSecretsQueryHandler(ISecretRepository secretRepository, IMapper mapper)
        {
            _secretRepository = secretRepository;
            _mapper = mapper;
        }

        public async Task<List<SecretDto>> Handle(GetAllSecretsQuery request, CancellationToken cancellationToken)
        {
            var result = await _secretRepository.GetAllSecretsAsync();

            //automapper to convert it back to secretDto
            var secretDto = _mapper.Map<IEnumerable<SecretDto>>(result);
            return secretDto.ToList();
        }
    }
}