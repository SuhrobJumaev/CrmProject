namespace Crm.BusinessLogic;

using Crm.DataAccess;


public sealed class ClientService : IClientService
{
    private readonly List<Client> _createdClientsList = new();
    private int _id;

    public ClientDto CreateClient(ClientDto clientDto)
    {
        Client client = clientDto.ClientDtoToClient();
        
        _createdClientsList.Add(client);

        return client.ClientToClientDto();
    }

    public List<ClientDto> GetListAllCreatedClients()
    {
        return _createdClientsList.ClientListToClientDtoList();
    }

    public List<ClientDto> GetClientByNameAndSurname(string firstName, string lastName)
    {
        List<Client> clients = _createdClientsList.Where(c => c.FirstName == firstName && c.LastName == lastName).ToList();
        return clients.ClientListToClientDtoList();
    }

    public bool UpdateClientById(int id, string firstName, string lastName)
    {
        Client client  = _createdClientsList.FirstOrDefault(c => c.Id == id); 

        if(client is null)
        {
            return false;
        }

        client.FirstName = firstName;
        client.LastName = lastName;

        return true;
    }

    public bool DeleteClient(int id)
    {
        Client client  = _createdClientsList.Find(c => c.Id == id); 
        
        if(client is null)
        {
            return false;
        }
        
        return  _createdClientsList.Remove(client);
    }

     private int NextId()
    {
        return ++_id;
    }

}
