using System.Text.RegularExpressions;
using Hasin.Domain.Common;

namespace Hasin.Domain.PhoneBook;

public sealed partial record PhoneNumber
{
    private PhoneNumber(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static PhoneNumber Create(string value)
    {
        value = value?.Trim() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(value))
        {
            throw new DomainException("Phone number is required.");
        }

        if (value.Length is < 7 or > 20 || !PhoneNumberRegex().IsMatch(value))
        {
            throw new DomainException("Phone number format is invalid.");
        }

        return new PhoneNumber(value);
    }

    [GeneratedRegex(@"^\+?[0-9][0-9\s\-()]*$")]
    private static partial Regex PhoneNumberRegex();
}
