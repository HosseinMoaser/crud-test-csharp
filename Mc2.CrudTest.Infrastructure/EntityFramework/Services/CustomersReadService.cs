using Mc2.CrudTest.Application.Services;
using Mc2.CrudTest.Infrastructure.EntityFramework.Contexts;
using Mc2.CrudTest.Infrastructure.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infrastructure.EntityFramework.Services;

internal sealed class CustomersReadService : ICustomersReadService
{
    private readonly DbSet<CustomerReadModel> _customers;

    public CustomersReadService(ReadDbContext context)
    {
        _customers = context.Customers;
    }
    public Task<bool> ExistsByEmail(string email)
    {
        return _customers.AnyAsync(pl=> pl.Email == email);
    }

    public Task<bool> ExistsByNameAndBirthday(string firstName, string lastName, DateTime dateofBirth)
    {
        return _customers.AnyAsync(pl => pl.FirstName == firstName &&
        pl.LastName == lastName && pl.DateofBirth ==dateofBirth);
    }
}
