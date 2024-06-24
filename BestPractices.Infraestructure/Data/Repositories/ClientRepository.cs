﻿using BestPractices.Application.Services;
using BestPractices.Domain.Repositories;
using BestPractices.Domain.ValueObjects;
using BestPractices.Infraestructure.Data.DbContextConfig;
using Microsoft.Extensions.Logging;

namespace BestPractices.Infraestructure.Data.Repositories;

/// <summary>
/// Classe de Repositorio do Cliente
/// </summary>
public class ClientRepository : IClientRepository
{

    private readonly ApplicationDbContext context;
    private readonly ILogger<ClientRepository> logger;

    /// <summary>
    /// Construtor 
    /// </summary>
    /// <param name="context"></param>
    /// <param name="logger"></param>
    public ClientRepository(ApplicationDbContext context, ILogger<ClientRepository> logger)
    {
        this.context = context;       
        this.logger = logger;
    }

    public async Task<bool> RegisterClient(Client clientRequest)
    {
        logger.LogInformation($"{nameof(ClientRepository)} - Registering customer...");

        try
        {
            await context.Clients.AddAsync(clientRequest);
            var isSuccessRegister = await context.SaveChangesAsync();

            logger.LogInformation("The customer has been registered successfully");
            return isSuccessRegister > 0;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed when trying to register the customer");
            return false;
        }
    }
}