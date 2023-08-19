using Mc2.CrudTest.Application.DTOs;
using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Shared.Abstraction.Queries;

namespace Mc2.CrudTest.Application.Queries;

public class GetAllCustomersQuery : IQuery<IEnumerable<CustomerDto>>
{
    public List<Customer> Customers { get; set; }
}
