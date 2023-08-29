namespace Crm.BusinessLogic;

using Crm.DataAccess;


public sealed class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public ClientDto? CreateClient(ClientDto clientDto)
    {
        Client client = _clientRepository.Create(clientDto.ClientDtoToClient());
        
        if(client is null)
            return null;

        return client.ClientToClientDto();
    }

    public IEnumerable<ClientDto>? GetListAllCreatedClients()
    {
        List<Client> clients = _clientRepository.GetAll();

        if(clients is null)
            return null;

        return clients.ClientListToClientDtoList();
    }

    public IEnumerable<ClientDto>? GetClientByNameAndSurname(string firstName, string lastName)
    {
        List<Client> clients = _clientRepository.GetClientByNameAndSurname(firstName, lastName);

        if(clients is null)
            return null;

        return clients.ClientListToClientDtoList();
    }

    public bool UpdateClientById(int id, string firstName, string lastName)
    {
        return _clientRepository.UpdateClientById(id,firstName, lastName);
    }

    public bool DeleteClient(int id)
    {
        return _clientRepository.Delete(id);
    }
}
