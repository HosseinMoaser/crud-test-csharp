using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.Repositories;
using Mc2.CrudTest.Domain.ValueObjects;
using Mc2.CrudTest.Infrastructure.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infrastructure.EntityFramework.Repositories;

internal sealed class CustomerRepository : ICustomerRepository
{
    private readonly DbSet<Customer> _customers;
    private readonly WriteDbContext _writeDbContext;

    public CustomerRepository(WriteDbContext writeDbContext)
    {
        _customers = writeDbContext.Customers;
        _writeDbContext = writeDbContext;
    }

    public async Task<IEnumerable<Customer>> GetCustomersAsync()
    {
        return await _customers.ToListAsync();
    }

    public Task<Customer> GetCustomerByIdAsync(CustomerId id)
    {
        return _customers.SingleOrDefaultAsync(pl => pl.Id == id);
    }


    public async Task AddCustomerAsync(Customer customer)
    {
        await _customers.AddAsync(customer);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task UpdateCustomerAsync(Customer customer)
    {
        _customers.Update(customer);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task DeleteCustomerAsync(Customer customer)
    {
        _customers.Remove(customer);
        await _writeDbContext.SaveChangesAsync();
    }
}
