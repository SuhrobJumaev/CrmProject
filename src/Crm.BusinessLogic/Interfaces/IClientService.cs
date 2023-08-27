namespace Crm.BusinessLogic;


using Crm.DataAccess;

public interface IClientService
{
    ClientDto CreateClient(ClientDto clientDto);
    List<ClientDto> GetListAllCreatedClients();
    List<ClientDto> GetClientByNameAndSurname(string firstName, string lastName);
    bool UpdateClientById(int id,string firstName, string lastName);
    bool DeleteClient(int id);
}
