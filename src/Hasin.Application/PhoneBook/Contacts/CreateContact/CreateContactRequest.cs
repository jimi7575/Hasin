namespace Hasin.Application.PhoneBook.Contacts.CreateContact;

public sealed record CreateContactRequest(
    string FirstName,
    string LastName,
    string PhoneNumber,
    string Tag);
