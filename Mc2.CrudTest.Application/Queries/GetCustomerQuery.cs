using Mc2.CrudTest.Application.DTOs;
using Mc2.CrudTest.Shared.Abstraction.Queries;

namespace Mc2.CrudTest.Application.Queries;

public class GetCustomerQuery : IQuery<CustomerDto>
{
    public Guid Id { get; set; }
}
