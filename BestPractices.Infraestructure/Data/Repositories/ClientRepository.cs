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

    public async Task<Guid> RegisterClient(Client clientRequest)
    {
        logger.LogInformation($"{nameof(ClientRepository)} - Registering customer...");

        try
        {
            //------------------------------------------------------------------------------//

            // O codigo abaixo seria para inserir em um banco de dados real
            // await context.Clients.AddAsync(clientRequest);
            // return context.Clients.Select(x => x.Id).FirstOrDefault();

            //------------------------------------------------------------------------------//


            //Irei simular um retorno de sucesso ao cadastrar o cliente no banco de dados
            return Guid.NewGuid();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed when trying to register the customer");
            throw;
        }
    }
}