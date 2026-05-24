using FluentValidation;
using Hasin.Application.PhoneBook.Contacts.Shared;

namespace Hasin.Application.PhoneBook.Contacts.UpdateContact;

public sealed class UpdateContactCommandValidator : AbstractValidator<UpdateContactCommand>
{
    public UpdateContactCommandValidator()
    {
        RuleFor(command => command.Id).NotEmpty();
        RuleFor(command => command.Contact).NotNull();
        RuleFor(command => command.Contact.FirstName).ValidFirstName();
        RuleFor(command => command.Contact.LastName).ValidLastName();
        RuleFor(command => command.Contact.PhoneNumber).ValidPhoneNumber();
        RuleFor(command => command.Contact.Tag).ValidTag();
    }
}
