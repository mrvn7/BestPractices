using BestPractices.Domain.ValueObjects;

namespace BestPractices.Domain.Repositories;

public interface IClientRepository
{
    Task<bool> RegisterClient(Client clientRequest);
}