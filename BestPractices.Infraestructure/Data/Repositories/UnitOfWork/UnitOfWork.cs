using BestPractices.Domain.Repositories;
using BestPractices.Domain.Repositories.UnitOfWork;
using BestPractices.Infraestructure.Data.DbContextConfig;
using Microsoft.Extensions.Logging;

namespace BestPractices.Infraestructure.Data.Repositories.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext context;
    private readonly ILogger<ClientRepository> logger;

    public IClientRepository Clients { get; }


    public UnitOfWork(ApplicationDbContext context, ILogger<ClientRepository> logger)
    {
        this.context = context;
        this.logger = logger;
        Clients = new ClientRepository(this.context, this.logger);
    }

    public async Task<bool> Commit()
    {
        // Esté é um projeto para meu portifolio, o mesmo não tem conexão com um banco de dados real,
        // com o der qualquer pessoa poder baixar e executar o projeto com a finalidade
        // de verificar como estas boas praticas são implementadas...

        //-----------------------------------------------------------//

        //verifica se os dados do cliente foram salvos com sucesso
        //return await context.SaveChangesAsync() > 0;

        //-----------------------------------------------------------//


        //simulo aqui o tempo de execução do metodo e seu retorno positivo

        await Task.Delay(100);
        return true;
    }

    public void Dispose()
    {
        context.Dispose();
    }
}