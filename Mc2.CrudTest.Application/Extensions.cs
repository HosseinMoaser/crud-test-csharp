using Mc2.CrudTest.Domain.Factories;
using Mc2.CrudTest.Shared.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace Mc2.CrudTest.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddCommands();
        services.AddSingleton<ICustomerFactory, CustomerFactory>();

        return services;
    }
}
