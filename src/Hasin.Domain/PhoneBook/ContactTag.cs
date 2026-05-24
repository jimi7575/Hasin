using Hasin.Domain.Common;

namespace Hasin.Domain.PhoneBook;

public sealed record ContactTag
{
    private ContactTag(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static ContactTag Create(string value)
    {
        value = value?.Trim() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(value))
        {
            throw new DomainException("Tag is required.");
        }

        if (value.Length > 100)
        {
            throw new DomainException("Tag must be 100 characters or fewer.");
        }

        return new ContactTag(value);
    }
}
