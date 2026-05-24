using FluentValidation;
using Hasin.Application.PhoneBook.Contacts.Shared;

namespace Hasin.Application.PhoneBook.Contacts.GetContactsByTag;

public sealed class GetContactsByTagQueryValidator : AbstractValidator<GetContactsByTagQuery>
{
    public GetContactsByTagQueryValidator()
    {
        RuleFor(query => query.Tag).ValidTag();
    }
}
