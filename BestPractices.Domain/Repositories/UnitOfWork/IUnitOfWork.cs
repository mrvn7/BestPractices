namespace BestPractices.Domain.Repositories.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IClientRepository Clients { get; }
    Task<bool> Commit();
}