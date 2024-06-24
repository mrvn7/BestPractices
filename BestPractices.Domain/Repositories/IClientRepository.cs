using BestPractices.Domain.ValueObjects;

namespace BestPractices.Domain.Repositories;

public interface IClientRepository
{
    Task<Guid> RegisterClient(Client clientRequest);
}