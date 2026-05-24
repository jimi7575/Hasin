using Hasin.Application.Abstractions;
using Hasin.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Hasin.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IContactRepository, InMemoryContactRepository>();
        return services;
    }
}
