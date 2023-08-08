namespace Crm.interfaces;

using Crm.Entities;
using Crm.Entities.Dtos;

public interface IClientService
{
    Client CreateClient(ClientDto clientDto);
    List<Client> GetListAllCreatedClients();
    List<Client> GetClientByNameAndSurname(string firstName, string lastName);
}
