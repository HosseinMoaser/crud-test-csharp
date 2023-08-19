using Mc2.CrudTest.Application.Services;
using Mc2.CrudTest.Domain.Repositories;
using Mc2.CrudTest.Infrastructure.EntityFramework.Commands;
using Mc2.CrudTest.Infrastructure.EntityFramework.Contexts;
using Mc2.CrudTest.Infrastructure.EntityFramework.Options;
using Mc2.CrudTest.Infrastructure.EntityFramework.Repositories;
using Mc2.CrudTest.Infrastructure.EntityFramework.Services;
using Mc2.CrudTest.Shared.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mc2.CrudTest.Infrastructure.EntityFramework;

internal static class Extensions
{
    public static IServiceCollection AddSQLDB(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<ICustomersReadService, CustomersReadService>();

        var options = configuration.GetOptions<DataBaseOptions>("DataBaseConnectionString");
        services.AddDbContext<ReadDbContext>(ctx =>
        ctx.UseSqlServer(options.ConnectionString));
        services.AddDbContext<WriteDbContext>(ctx =>
            ctx.UseSqlServer(options.ConnectionString));
        services.AddCommands();
        return services;
    }
}
