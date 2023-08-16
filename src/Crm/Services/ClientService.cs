namespace Crm.Serices;


using Crm.DataAccess;
using Crm.interfaces;


public sealed class ClientService : IClientService
{
    private readonly List<Client> _createdClientsList = new();
    private int _id;

    public Client CreateClient(ClientDto clientDto)
    {

        Client client = new()
        {
            Id  = NextId(),
            FirstName = clientDto.FirstName,
            LastName = clientDto.LastName,
            MiddleName = clientDto.MiddleName,
            Age = clientDto.Age,
            PassportNumber = clientDto.PassportNumber,
            Gender = clientDto.Gender,
            Phone = clientDto.Phone,
            Email = clientDto.Email,
            Password = clientDto.Password
        };
        _createdClientsList.Add(client);
        return client;
    }

    public List<Client> GetListAllCreatedClients()
    {
        return _createdClientsList;
    }

    public List<Client> GetClientByNameAndSurname(string firstName, string lastName)
    {
        return _createdClientsList.FindAll(c => c.FirstName == firstName && c.LastName == lastName).ToList();
    }

    public Client UpdateClientById(int id, string firstName, string lastName)
    {
        Client client  = _createdClientsList.Find(c => c.Id == id); 

        if(client == null)
        {
            return null;
        }

        client.FirstName = firstName;
        client.LastName = lastName;

        return client;
    }

    public bool DeleteClient(int id)
    {
        Client client  = _createdClientsList.Find(c => c.Id == id); 
        
        if(client == null)
        {
            return false;
        }
        
        var result = _createdClientsList.Remove(client);

        return result;
    }

     private int NextId()
    {
        return ++_id;
    }
}
