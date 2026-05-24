using FluentValidation;
using Hasin.Application.Abstractions;
using Hasin.Application.Common;
using Hasin.Application.PhoneBook.Contacts.Shared;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Hasin.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddScoped<IContactService, ContactService>();

        return services;
    }
}
