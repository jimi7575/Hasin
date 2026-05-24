using FluentValidation;
using Hasin.Domain.PhoneBook;

namespace Hasin.Application.PhoneBook.Contacts.Shared;

internal static class ContactValidationRules
{
    public static IRuleBuilderOptions<T, string> ValidFirstName<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty()
            .MaximumLength(80);
    }

    public static IRuleBuilderOptions<T, string> ValidLastName<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty()
            .MaximumLength(80);
    }

    public static IRuleBuilderOptions<T, string> ValidPhoneNumber<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty()
            .Length(7, 20)
            .Matches(PhoneNumber.Pattern);
    }

    public static IRuleBuilderOptions<T, string> ValidTag<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty()
            .MaximumLength(100);
    }
}
