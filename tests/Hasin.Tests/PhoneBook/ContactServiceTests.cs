using Hasin.Application.Common;
using Hasin.Application.PhoneBook.Contacts.CreateContact;
using Hasin.Application.PhoneBook.Contacts.Shared;
using Hasin.Application.PhoneBook.Contacts.UpdateContact;
using Hasin.Infrastructure.Persistence;

namespace Hasin.Tests.PhoneBook;

public sealed class ContactServiceTests
{
    [Fact]
    public async Task Create_then_get_by_tag_returns_matching_contacts_case_insensitively()
    {
        var service = CreateService();

        await service.CreateAsync(new CreateContactRequest("Ali", "Ahmadi", "09121234567", "Terabarnet"), CancellationToken.None);
        await service.CreateAsync(new CreateContactRequest("Sara", "Karimi", "09121234568", "Family"), CancellationToken.None);

        var contacts = await service.GetByTagAsync("terabarnet", CancellationToken.None);

        var contact = Assert.Single(contacts);
        Assert.Equal("Ali", contact.FirstName);
        Assert.Equal("Terabarnet", contact.Tag);
    }

    [Fact]
    public async Task Update_existing_contact_replaces_values()
    {
        var service = CreateService();
        var created = await service.CreateAsync(new CreateContactRequest("Ali", "Ahmadi", "09121234567", "Work"), CancellationToken.None);

        var updated = await service.UpdateAsync(
            created.Id,
            new UpdateContactRequest("Reza", "Moradi", "0211234567", "Office"),
            CancellationToken.None);

        Assert.Equal(created.Id, updated.Id);
        Assert.Equal("Reza", updated.FirstName);
        Assert.Equal("Moradi", updated.LastName);
        Assert.Equal("0211234567", updated.PhoneNumber);
        Assert.Equal("Office", updated.Tag);
    }

    [Fact]
    public async Task Delete_existing_contact_removes_it_from_tag_results()
    {
        var service = CreateService();
        var created = await service.CreateAsync(new CreateContactRequest("Ali", "Ahmadi", "09121234567", "Work"), CancellationToken.None);

        await service.DeleteAsync(created.Id, CancellationToken.None);

        var contacts = await service.GetByTagAsync("Work", CancellationToken.None);
        Assert.Empty(contacts);
    }

    [Fact]
    public async Task Updating_missing_contact_throws_not_found()
    {
        var service = CreateService();

        await Assert.ThrowsAsync<NotFoundException>(() => service.UpdateAsync(
            Guid.NewGuid(),
            new UpdateContactRequest("Ali", "Ahmadi", "09121234567", "Work"),
            CancellationToken.None));
    }

    private static ContactService CreateService()
    {
        return new ContactService(new InMemoryContactRepository());
    }
}
