using FluentValidation;
using Hasin.Application;
using Hasin.Application.PhoneBook.Contacts.CreateContact;
using Hasin.Infrastructure;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Hasin.Tests.PhoneBook;

public sealed class ValidationTests
{
    [Fact]
    public async Task Mediator_rejects_invalid_create_command_before_handler()
    {
        var sender = CreateSender();

        await Assert.ThrowsAsync<ValidationException>(() => sender.Send(
            new CreateContactCommand(new CreateContactRequest("", "Ahmadi", "abc", "")),
            CancellationToken.None));
    }

    [Fact]
    public async Task Mediator_accepts_valid_create_command()
    {
        var sender = CreateSender();

        var contact = await sender.Send(
            new CreateContactCommand(new CreateContactRequest("Ali", "Ahmadi", "09121234567", "Work")),
            CancellationToken.None);

        Assert.NotEqual(Guid.Empty, contact.Id);
    }

    private static ISender CreateSender()
    {
        var services = new ServiceCollection()
            .AddApplication()
            .AddInfrastructure()
            .BuildServiceProvider();

        return services.GetRequiredService<ISender>();
    }
}
