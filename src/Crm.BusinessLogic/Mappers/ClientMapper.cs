namespace Crm.BusinessLogic;

using Crm.DataAccess;

public static class ClientMapper 
{
    public static ClientDto ClientToClientDto(this Client client)
    {
        return new ClientDto()
        {
            Id= client.Id,
            FirstName = client.FirstName,
            LastName = client.LastName,
            MiddleName = client.MiddleName,
            PassportNumber = client.PassportNumber,
            Phone = client.Phone,
            Age = client.Age,
            Gender  = (int)client.Gender,
            Email = client.Email,
            Password = client.Password
        };
    }

    public static Client ClientDtoToClient(this ClientDto clientDto)
    {
        return new () 
        {
            FirstName = clientDto.FirstName,
            LastName = clientDto.LastName,
            MiddleName = clientDto.MiddleName,
            Age = clientDto.Age,
            PassportNumber = clientDto.PassportNumber,
            Gender = (Gender)clientDto.Gender,
            Phone = clientDto.Phone,
            Email = clientDto.Email,
            Password = clientDto.Password,
        };
    }

    public static List<ClientDto> ClientListToClientDtoList(this List<Client> clients)
    {
        List<ClientDto> clientsDto = new();

        clientsDto = clients.Select(c => new ClientDto
        {
            FirstName = c.FirstName,
            LastName = c.LastName,
            MiddleName = c.MiddleName,
            Age = c.Age,
            PassportNumber = c.PassportNumber,
            Gender = (int)c.Gender,
            Phone = c.Phone,
            Email = c.Email,
            Password = c.Password,
        }).ToList();
        
        return clientsDto;
    }

    public static List<Client> ClientListDtoToClientList(this List<ClientDto> clientsDto)
    {
        List<Client> clients = new();

        clients = clientsDto.Select(c => new Client
        {
            FirstName = c.FirstName,
            LastName = c.LastName,
            MiddleName = c.MiddleName,
            Age = c.Age,
            PassportNumber = c.PassportNumber,
            Gender = (Gender)c.Gender,
            Phone = c.Phone,
            Email = c.Email,
            Password = c.Password,
        }).ToList();
        
        return clients;
    }

}