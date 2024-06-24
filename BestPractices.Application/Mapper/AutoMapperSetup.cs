using AutoMapper;
using BestPractices.Application.Requests;
using BestPractices.Domain.ValueObjects;

namespace BestPractices.Application.Mapper
{
    public class AutoMapperSetup : Profile
    {

        public AutoMapperSetup() 
        {
            #region Configuração mapper da classe de cliente
            CreateMap<Client, ClientRequest>();
            CreateMap<ClientRequest, Client>();
            #endregion
        }
    }
}