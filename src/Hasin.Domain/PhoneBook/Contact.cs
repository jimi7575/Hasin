using Hasin.Domain.Common;

namespace Hasin.Domain.PhoneBook;

public sealed class Contact : Entity<Guid>, IAggregateRoot
{
    private Contact(Guid id, PersonName name, PhoneNumber phoneNumber, ContactTag tag)
        : base(id)
    {
        Name = name;
        PhoneNumber = phoneNumber;
        Tag = tag;
        CreatedAtUtc = DateTimeOffset.UtcNow;
        UpdatedAtUtc = CreatedAtUtc;
    }

    public PersonName Name { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public ContactTag Tag { get; private set; }
    public DateTimeOffset CreatedAtUtc { get; }
    public DateTimeOffset UpdatedAtUtc { get; private set; }

    public static Contact Create(PersonName name, PhoneNumber phoneNumber, ContactTag tag)
    {
        return new Contact(Guid.NewGuid(), name, phoneNumber, tag);
    }

    public void Update(PersonName name, PhoneNumber phoneNumber, ContactTag tag)
    {
        Name = name;
        PhoneNumber = phoneNumber;
        Tag = tag;
        UpdatedAtUtc = DateTimeOffset.UtcNow;
    }
}
