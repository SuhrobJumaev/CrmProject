namespace Crm.BusinessLogic;

using Crm.DataAccess;


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
        return _createdClientsList.Where(c => c.FirstName == firstName && c.LastName == lastName).ToList();
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
