using Mc2.CrudTest.Application.DTOs;
using Mc2.CrudTest.Domain.Repositories;
using Mc2.CrudTest.Infrastructure.EntityFramework.Contexts;
using Mc2.CrudTest.Infrastructure.EntityFramework.Models;
using Mc2.CrudTest.Infrastructure.EntityFramework.Queries;
using Mc2.CrudTest.Shared.Abstraction.Queries;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Application.Queries.Handlers;

public class GetCustomerQueryHandler : IQueryHandler<GetCustomerQuery, CustomerDto>
{
    private readonly DbSet<CustomerReadModel> _customers;

    public GetCustomerQueryHandler(ReadDbContext context)
    {
        _customers = context.Customers;
    }

    public async Task<CustomerDto> HandleAsync(GetCustomerQuery query)
    {
        return await _customers.Where(pl => pl.Id == query.Id)
            .Select(pl=> pl.MapToDto())
            .AsNoTracking()
            .SingleOrDefaultAsync();
    }
}
