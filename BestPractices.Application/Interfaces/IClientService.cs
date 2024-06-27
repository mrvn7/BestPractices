using BestPractices.Application.DTOs;
using BestPractices.Application.Requests;
using BestPractices.Domain.Repositories.UnitOfWork;

namespace BestPractices.Application.Interfaces;

public interface IClientService
{
    Task<ClientDTO> RegisterClient(ClientRequest clientRequest);
}