using BestPractices.Application.Requests;
using BestPractices.Domain.Repositories;
using BestPractices.Domain.ValueObjects;

namespace BestPractices.Infraestructure.Data.Repositories;

public class ClientRepository : IClientRepository
{
    public ClientRepository()
    {
            
    }

    public Task<bool> RegisterClient(Client clientRequest)
    {
        var email = clientRequest.Email;

        throw new NotImplementedException();
    }
}