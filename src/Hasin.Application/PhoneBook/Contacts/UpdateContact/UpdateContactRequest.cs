namespace Hasin.Application.PhoneBook.Contacts.UpdateContact;

public sealed record UpdateContactRequest(
    string FirstName,
    string LastName,
    string PhoneNumber,
    string Tag);
