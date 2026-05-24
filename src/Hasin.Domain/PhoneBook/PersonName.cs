using Hasin.Domain.Common;

namespace Hasin.Domain.PhoneBook;

public sealed record PersonName
{
    private PersonName(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName { get; }
    public string LastName { get; }

    public static PersonName Create(string firstName, string lastName)
    {
        firstName = Normalize(firstName);
        lastName = Normalize(lastName);

        if (string.IsNullOrWhiteSpace(firstName))
        {
            throw new DomainException("First name is required.");
        }

        if (string.IsNullOrWhiteSpace(lastName))
        {
            throw new DomainException("Last name is required.");
        }

        if (firstName.Length > 80 || lastName.Length > 80)
        {
            throw new DomainException("First name and last name must be 80 characters or fewer.");
        }

        return new PersonName(firstName, lastName);
    }

    private static string Normalize(string value) => value?.Trim() ?? string.Empty;
}
