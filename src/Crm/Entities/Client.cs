namespace Crm.Entities;

public class Client
{
    private readonly string? _firstName;
    private readonly string? _lastName;
    private string? _middleName;
    private short _age;
    private readonly string? _passportNumber;
    private readonly Gender? _gender;
    private string? _phone;
    private string? _email;
    private string? _password;

    public required string FirstName
    {
        get => _firstName ?? string.Empty;
        init => _firstName = value is { Length: > 0 } ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }

    public required string LastName
    {
        get => _lastName ?? string.Empty;
        init => _lastName = value is { Length: > 0 } ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }

    public string? MiddleName
    {
        get => _middleName ?? string.Empty;
        set => _middleName = value;
    }

    public short Age
    {
        get => _age;
        init => _age = value;
    }

    public required string? PassportNumber
    {
        get => _passportNumber ?? string.Empty;
        init => _passportNumber = value is { Length: > 0 } ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }

    public required Gender? Gender
    {
        get => _gender ?? null;
        init => _gender = value is not null ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }

    public required string Phone
    {
        get => _phone ?? string.Empty;
        init => _phone = value is { Length: > 0 } ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }

    public required string Email
    {
        get => _email ?? string.Empty;
        init => _email = value is { Length: > 0 } ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }

    public required string Password
    {
        get => _password ?? string.Empty;
        init => _password = value is { Length: > 0 } ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }
}
