﻿using AutoMapper;
using BestPractices.Application.Interfaces;
using BestPractices.Application.Requests;
using BestPractices.Domain.Repositories;
using BestPractices.Domain.ValueObjects;
using Microsoft.Extensions.Logging;

namespace BestPractices.Application.Services;

/// <summary>
/// Classe de serviço do Cliente
/// </summary>
public class ClientService : IClientService
{
    private readonly IClientRepository clientRepository;
    private readonly IMapper mapper;
    private readonly ILogger<ClientService> logger;

    /// <summary>
    /// Construtor
    /// </summary>
    /// <param name="clientRepository"></param>
    /// <param name="logger"></param>
    public ClientService(IClientRepository clientRepository, IMapper mapper, ILogger<ClientService> logger)
    {
        this.clientRepository = clientRepository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<bool> RegisterClient(ClientRequest clientRequest)
    {
        logger.LogInformation($"{nameof(ClientService)} - Sending data to domain layer");

        var client = mapper.Map<Client>(clientRequest);
        return await clientRepository.RegisterClient(client);
    }
}