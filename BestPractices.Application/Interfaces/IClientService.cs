using BestPractices.Application.DTOs;
using BestPractices.Application.Requests;

namespace BestPractices.Application.Interfaces;

public interface IClientService
{
    Task<ClientDTO> RegisterClient(ClientRequest clientRequest);
}