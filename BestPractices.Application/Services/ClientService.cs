using AutoMapper;
using BestPractices.Application.Interfaces;
using BestPractices.Application.Requests;
using BestPractices.Domain.Repositories;
using BestPractices.Domain.ValueObjects;

namespace BestPractices.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository clientRepository;
        private readonly IMapper mapper;

        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {
            this.clientRepository = clientRepository;
            this.mapper = mapper;
        }

        public Task<bool> RegisterClient(ClientRequest clientRequest)
        {
            var client = mapper.Map<Client>(clientRequest);

            clientRepository.RegisterClient(client);

            throw new NotImplementedException();
        }
    }
}