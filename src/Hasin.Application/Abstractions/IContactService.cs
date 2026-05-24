using Hasin.Application.PhoneBook.Contacts.CreateContact;
using Hasin.Application.PhoneBook.Contacts.Shared;
using Hasin.Application.PhoneBook.Contacts.UpdateContact;

namespace Hasin.Application.Abstractions;

public interface IContactService
{
    Task<ContactDto> CreateAsync(CreateContactRequest request, CancellationToken cancellationToken);
    Task<ContactDto> UpdateAsync(Guid id, UpdateContactRequest request, CancellationToken cancellationToken);
    Task<IReadOnlyCollection<ContactDto>> GetByTagAsync(string tag, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}
