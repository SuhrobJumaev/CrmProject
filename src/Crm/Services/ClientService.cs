namespace Crm.Serices;

using Crm.Entities;
using Crm.Entities.Dtos;

public sealed class ClientService
{
    public Client CreateClient(ClientDto clientDto)
    {

        return new()
        {
            FirstName = clientDto.FirstName,
            LastName = clientDto.LastName,
            MiddleName = clientDto.MiddleName,
            Age = clientDto.Age,
            PassportNumber = clientDto.PassportNumber,
            Gender = clientDto.Gender,
        };
    }
}
