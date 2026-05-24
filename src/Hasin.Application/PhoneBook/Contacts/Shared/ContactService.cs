using Hasin.Application.Abstractions;
using Hasin.Application.Common;
using Hasin.Application.PhoneBook.Contacts.CreateContact;
using Hasin.Application.PhoneBook.Contacts.UpdateContact;
using Hasin.Domain.PhoneBook;

namespace Hasin.Application.PhoneBook.Contacts.Shared;

public sealed class ContactService : IContactService
{
    private readonly IContactRepository _repository;

    public ContactService(IContactRepository repository)
    {
        _repository = repository;
    }

    public async Task<ContactDto> CreateAsync(CreateContactRequest request, CancellationToken cancellationToken)
    {
        var contact = Contact.Create(
            PersonName.Create(request.FirstName, request.LastName),
            PhoneNumber.Create(request.PhoneNumber),
            ContactTag.Create(request.Tag));

        await _repository.AddAsync(contact, cancellationToken);
        return contact.ToDto();
    }

    public async Task<ContactDto> UpdateAsync(Guid id, UpdateContactRequest request, CancellationToken cancellationToken)
    {
        var contact = await _repository.GetByIdAsync(id, cancellationToken)
            ?? throw new NotFoundException($"Contact '{id}' was not found.");

        contact.Update(
            PersonName.Create(request.FirstName, request.LastName),
            PhoneNumber.Create(request.PhoneNumber),
            ContactTag.Create(request.Tag));

        await _repository.UpdateAsync(contact, cancellationToken);
        return contact.ToDto();
    }

    public async Task<IReadOnlyCollection<ContactDto>> GetByTagAsync(string tag, CancellationToken cancellationToken)
    {
        var contacts = await _repository.GetByTagAsync(ContactTag.Create(tag), cancellationToken);
        return contacts.Select(contact => contact.ToDto()).ToArray();
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var contact = await _repository.GetByIdAsync(id, cancellationToken)
            ?? throw new NotFoundException($"Contact '{id}' was not found.");

        await _repository.DeleteAsync(contact.Id, cancellationToken);
    }
}
