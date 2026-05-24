namespace Hasin.Application.PhoneBook.Contacts.Shared;

public sealed record ContactDto(
    Guid Id,
    string FirstName,
    string LastName,
    string PhoneNumber,
    string Tag,
    DateTimeOffset CreatedAtUtc,
    DateTimeOffset UpdatedAtUtc);
