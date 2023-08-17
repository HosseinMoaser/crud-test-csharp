using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.ValueObjects;

namespace Mc2.CrudTest.Domain.Repositories;

public interface ICustomerRepository
{
    Task<List<Customer>> GetCustomersAsync();
    Task<Customer> GetCustomerByIdAsync(CustomerId id);
    Task AddCustomerAsync(Customer customer);
    Task UpdateCustomerAsync(Customer customer);
    Task DeleteCustomerAsync(Customer customer);
}
