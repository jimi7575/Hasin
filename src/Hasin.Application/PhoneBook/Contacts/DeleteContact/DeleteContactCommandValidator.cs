using FluentValidation;

namespace Hasin.Application.PhoneBook.Contacts.DeleteContact;

public sealed class DeleteContactCommandValidator : AbstractValidator<DeleteContactCommand>
{
    public DeleteContactCommandValidator()
    {
        RuleFor(command => command.Id).NotEmpty();
    }
}
