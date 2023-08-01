
using System.Text.RegularExpressions;

namespace Crm.Validators;

public static class ClientValidator
{
    private const string emailPattern = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
    private const string phonePattern = "^(992[0-9]{9})$";

    private static readonly Regex _allowedEmailRegex = new Regex(emailPattern, RegexOptions.Compiled);
    private static readonly Regex _allowedPhoneRegex = new Regex(phonePattern, RegexOptions.Compiled);

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

    public static bool IsValidPhone(string? phone)
    {
        if (string.IsNullOrEmpty(phone) || string.IsNullOrWhiteSpace(phone))
        {
            return false;
        }

        Match match = _allowedPhoneRegex.Match(phone);

        if (!match.Success)
        {
            return false;
        }

        return true;
    }
    public static bool IsValidEmail(string? email)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrWhiteSpace(email))
        {
            return false;
        }

        Match match = _allowedEmailRegex.Match(email);

        if (!match.Success)
        {
            return false;
        }

        return true;
    }
    public static bool IsValidPassword(string? password)
    {
        if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
        {
            return false;
        }

        return true;
    }
}
