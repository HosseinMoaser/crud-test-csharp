using Mc2.CrudTest.Application.DTOs;
using Mc2.CrudTest.Domain.Repositories;
using Mc2.CrudTest.Shared.Abstraction.Queries;

namespace Mc2.CrudTest.Application.Queries.Handlers;

public class GetAllCustomersQueryHandler : IQueryHandler<GetAllCustomersQuery, IEnumerable<CustomerDto>>
{
    private readonly ICustomerRepository _customerRepositoy;

    public GetAllCustomersQueryHandler(ICustomerRepository customerRepositoy)
    {
        _customerRepositoy = customerRepositoy;
    }

    public async Task<IEnumerable<CustomerDto>> HandleAsync(GetAllCustomersQuery query)
    {
        var customers = await _customerRepositoy.GetCustomersAsync();
        return null;
    }
}
