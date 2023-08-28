namespace Crm.DataAccess;

class ClientRepository : IClientRepository
{
    private readonly List<Client> _clientsList = new();
    private int _id;

    public Client Create(Client entity)
    {
        entity.Id = NextId();
        _clientsList.Add(entity);
        return entity;
    }

    public bool Delete(int id)
    {
        Client client  = _clientsList.FirstOrDefault(c => c.Id == id); 
        
        if(client is null)
        {
            return false;
        }
        
        return  _clientsList.Remove(client);
    }

    public Client? Get(int id)
    {
        return _clientsList.FirstOrDefault(c => c.Id == id);
    }

    public List<Client> GetAll()
    {
        return _clientsList;
    }

    public List<Client> GetClientByNameAndSurname(string name, string surname)
    {
        List<Client> clients = _clientsList.Where(c => c.FirstName == name && c.LastName == surname).ToList();
        return clients;
    }

    public bool UpdateClientById(int id, string name, string surname)
    {
        Client client  = _clientsList.FirstOrDefault(c => c.Id == id); 

        if(client is null)
        {
            return false;
        }

        client.FirstName = name;
        client.LastName = surname;

        return true;
    }
    
    private int NextId()
    {
        return ++_id;
    }
}
