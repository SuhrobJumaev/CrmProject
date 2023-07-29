
namespace Crm.Validators;

public static class ClientValidator
{
    public static bool IsValidFirstName(string? firstName)
    {
        if (string.IsNullOrEmpty(firstName) || string.IsNullOrWhiteSpace(firstName))
        {
            return false;
        }

        return true;
    }

    public static bool IsValidLastName(string? lastName)
    {
        if (string.IsNullOrEmpty(lastName) || string.IsNullOrWhiteSpace(lastName))
        {
            return false;
        }

        return true;
    }
    public static bool IsValidAge(string? ageString, out short age)
    {
        if (!short.TryParse(ageString, out age))
        {
            return false;
        }

        return true;
    }

    public static bool IsValidPassportId(string? passportId)
    {
        if (string.IsNullOrEmpty(passportId) || string.IsNullOrWhiteSpace(passportId))
        {
            return false;
        }

        return true;
    }

    public static bool IsValidGender(string? genderString, out short genderNumber)
    {
        if (!short.TryParse(genderString, out genderNumber))
        {
            return false;
        }

        if (!genderString.Equals("1") & !genderString.Equals("2"))
        {
            return false;
        }

        return true;
    }
}
