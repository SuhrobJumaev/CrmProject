namespace Crm.DataAccess;

public class Client
{
    private int _id;
    private  string? _firstName;
    private  string? _lastName;
    private string? _middleName;
    private short _age;
    private readonly string? _passportNumber;
    private readonly Gender? _gender;
    private string? _phone;
    private string? _email;
    private string? _password;

    public int Id
    {
        get => _id;
        set => _id = value;
    }
    public required string FirstName
    {
        get => _firstName ?? string.Empty;
        set => _firstName = value is { Length: > 0 } ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }

    public required string LastName
    {
        get => _lastName ?? string.Empty;
        set => _lastName = value is { Length: > 0 } ? value : throw new ArgumentOutOfRangeException(nameof(value));
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
