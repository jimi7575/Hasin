using Hasin.Domain.PhoneBook;

namespace Hasin.Application.PhoneBook.Contacts.Shared;

internal static class ContactMapper
{
    public static ContactDto ToDto(this Contact contact)
    {
        return new ContactDto(
            contact.Id,
            contact.Name.FirstName,
            contact.Name.LastName,
            contact.PhoneNumber.Value,
            contact.Tag.Value,
            contact.CreatedAtUtc,
            contact.UpdatedAtUtc);
    }
}
