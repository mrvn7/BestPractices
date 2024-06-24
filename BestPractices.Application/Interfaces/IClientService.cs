using BestPractices.Application.Requests;

namespace BestPractices.Application.Interfaces
{
    public interface IClientService
    {
        Task<bool> RegisterClient(ClientRequest clientRequest);
    }
}
