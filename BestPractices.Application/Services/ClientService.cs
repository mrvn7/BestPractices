using AutoMapper;
using BestPractices.Application.DTOs;
using BestPractices.Application.Interfaces;
using BestPractices.Application.Requests;
using BestPractices.Domain.Exceptions;
using BestPractices.Domain.Repositories.UnitOfWork;
using BestPractices.Domain.ValueObjects;
using Microsoft.Extensions.Logging;

namespace BestPractices.Application.Services;

/// <summary>
/// Classe de serviço do Cliente
/// </summary>
public class ClientService : IClientService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly ILogger<ClientService> logger;

    /// <summary>
    /// Construtor
    /// </summary>
    /// <param name="clientRepository"></param>
    /// <param name="logger"></param>
    public ClientService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ClientService> logger)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<ClientDTO> RegisterClient(ClientRequest clientRequest)
    {
        logger.LogInformation($"{nameof(ClientService)} - Sending data to domain layer");

        //faço o mapeamento
        var client = mapper.Map<Client>(clientRequest);

        //aguardo o registro do cliente
        var IdRegister = await unitOfWork.Clients.RegisterClient(client);

        //Chamo aqui meu UnitOfWork para fazer a logica do commit
        var isCommited = await unitOfWork.Commit();

        var clientDto = new ClientDTO();
        if (isCommited)
        {
            logger.LogInformation("The customer has been registered successfully");
            clientDto.Id = IdRegister;

            return clientDto;
        }

        throw new NotCommitedException();
    }
}