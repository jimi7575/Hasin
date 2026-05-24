using Hasin.Domain.Common;
using Hasin.Domain.PhoneBook;

namespace Hasin.Tests.PhoneBook;

public sealed class DomainTests
{
    [Fact]
    public void Create_contact_with_valid_values_sets_all_properties()
    {
        var contact = Contact.Create(
            PersonName.Create("Ali", "Ahmadi"),
            PhoneNumber.Create("+989121234567"),
            ContactTag.Create("Coworker"));

        Assert.NotEqual(Guid.Empty, contact.Id);
        Assert.Equal("Ali", contact.Name.FirstName);
        Assert.Equal("Ahmadi", contact.Name.LastName);
        Assert.Equal("+989121234567", contact.PhoneNumber.Value);
        Assert.Equal("Coworker", contact.Tag.Value);
    }

    [Theory]
    [InlineData("")]
    [InlineData("abc")]
    [InlineData("123")]
    public void Invalid_phone_number_is_rejected(string phoneNumber)
    {
        Assert.Throws<DomainException>(() => PhoneNumber.Create(phoneNumber));
    }

    [Fact]
    public void Update_contact_changes_mutable_fields()
    {
        var contact = Contact.Create(
            PersonName.Create("Ali", "Ahmadi"),
            PhoneNumber.Create("09121234567"),
            ContactTag.Create("Work"));

        contact.Update(
            PersonName.Create("Sara", "Karimi"),
            PhoneNumber.Create("0211234567"),
            ContactTag.Create("Office"));

        Assert.Equal("Sara", contact.Name.FirstName);
        Assert.Equal("Karimi", contact.Name.LastName);
        Assert.Equal("0211234567", contact.PhoneNumber.Value);
        Assert.Equal("Office", contact.Tag.Value);
    }
}
