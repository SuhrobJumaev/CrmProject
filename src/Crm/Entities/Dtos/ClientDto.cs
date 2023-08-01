namespace Crm.Entities.Dtos;

public readonly struct ClientDto
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string? MiddleName { get; init; }
    public short Age { get; init; }
    public string PassportNumber { get; init; }
    public Gender Gender { get; init; }
    public string Phone { get; init; }
    public string Email { get; init; }
    public string Password { get; init; }
}
