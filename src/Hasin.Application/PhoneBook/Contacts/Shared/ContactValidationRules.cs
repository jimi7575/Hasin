using FluentValidation;

namespace Hasin.Application.PhoneBook.Contacts.Shared;

internal static class ContactValidationRules
{
    private const string PhoneNumberPattern = @"^\+?[0-9][0-9\s\-()]*$";

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
            .Matches(PhoneNumberPattern);
    }

    public static IRuleBuilderOptions<T, string> ValidTag<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty()
            .MaximumLength(100);
    }
}
