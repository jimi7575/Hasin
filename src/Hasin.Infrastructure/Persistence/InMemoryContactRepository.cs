using System.Collections.Concurrent;
using Hasin.Application.Abstractions;
using Hasin.Domain.PhoneBook;

namespace Hasin.Infrastructure.Persistence;

public sealed class InMemoryContactRepository : IContactRepository
{
    private readonly ConcurrentDictionary<Guid, Contact> _contacts = new();

    public Task AddAsync(Contact contact, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        _contacts[contact.Id] = contact;
        return Task.CompletedTask;
    }

    public Task<Contact?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        _contacts.TryGetValue(id, out var contact);
        return Task.FromResult(contact);
    }

    public Task<IReadOnlyCollection<Contact>> GetByTagAsync(ContactTag tag, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var contacts = _contacts.Values
            .Where(contact => string.Equals(contact.Tag.Value, tag.Value, StringComparison.OrdinalIgnoreCase))
            .OrderBy(contact => contact.Name.LastName)
            .ThenBy(contact => contact.Name.FirstName)
            .ToArray();

        return Task.FromResult<IReadOnlyCollection<Contact>>(contacts);
    }

    public Task UpdateAsync(Contact contact, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        _contacts[contact.Id] = contact;
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        _contacts.TryRemove(id, out _);
        return Task.CompletedTask;
    }
}
