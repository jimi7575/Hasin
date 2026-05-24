using FluentValidation;
using Hasin.Application.PhoneBook.Contacts.Shared;

namespace Hasin.Application.PhoneBook.Contacts.CreateContact;

public sealed class CreateContactCommandValidator : AbstractValidator<CreateContactCommand>
{
    public CreateContactCommandValidator()
    {
        RuleFor(command => command.Contact).NotNull();
        RuleFor(command => command.Contact.FirstName).ValidFirstName();
        RuleFor(command => command.Contact.LastName).ValidLastName();
        RuleFor(command => command.Contact.PhoneNumber).ValidPhoneNumber();
        RuleFor(command => command.Contact.Tag).ValidTag();
    }
}
