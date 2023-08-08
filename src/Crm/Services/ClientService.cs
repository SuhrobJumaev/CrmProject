namespace Crm.Serices;

using Crm.Entities;
using Crm.Entities.Dtos;
using Crm.interfaces;
using Crm.DataAccess;

public sealed class ClientService : IClientService
{
    private readonly List<Client> _createdClientsList = new();
    public Client CreateClient(ClientDto clientDto)
    {

        Client client = new()
        {
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
}
