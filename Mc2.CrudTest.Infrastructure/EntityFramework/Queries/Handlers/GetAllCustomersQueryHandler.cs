using Mc2.CrudTest.Application.DTOs;
using Mc2.CrudTest.Infrastructure.EntityFramework.Contexts;
using Mc2.CrudTest.Infrastructure.EntityFramework.Models;
using Mc2.CrudTest.Infrastructure.EntityFramework.Queries;
using Mc2.CrudTest.Shared.Abstraction.Queries;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Application.Queries.Handlers;

public class GetAllCustomersQueryHandler : IQueryHandler<GetAllCustomersQuery, IEnumerable<CustomerDto>>
{
    private readonly DbSet<CustomerReadModel> _customers;

    public GetAllCustomersQueryHandler(ReadDbContext context)
    {
        _customers = context.Customers;
    }

    public async Task<IEnumerable<CustomerDto>> HandleAsync(GetAllCustomersQuery query)
    {
       var list = await _customers.Select(pl => pl.MapToDto())
            .AsNoTracking()
            .ToListAsync();
        return list;
    }
}
