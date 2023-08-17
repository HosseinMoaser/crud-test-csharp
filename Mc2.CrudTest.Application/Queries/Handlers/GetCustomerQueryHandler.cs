using Mc2.CrudTest.Application.DTOs;
using Mc2.CrudTest.Domain.Repositories;
using Mc2.CrudTest.Shared.Abstraction.Queries;

namespace Mc2.CrudTest.Application.Queries.Handlers;

public class GetCustomerQueryHandler : IQueryHandler<GetCustomerQuery, CustomerDto>
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomerQueryHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<CustomerDto> HandleAsync(GetCustomerQuery query)
    {
        var customer = _customerRepository.GetCustomerByIdAsync(query.Id);

        return null;
    }
}
