using Mc2.CrudTest.Application.Commands;
using Mc2.CrudTest.Application.Exceptions;
using Mc2.CrudTest.Application.Services;
using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.Factories;
using Mc2.CrudTest.Domain.Repositories;
using Mc2.CrudTest.Infrastructure.EntityFramework.Contexts;
using Mc2.CrudTest.Infrastructure.EntityFramework.Models;
using Mc2.CrudTest.Shared.Abstraction.Commands;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infrastructure.Commands.Handlers;

public sealed class UpdateCustomerCommandHandler : ICommandHandler<UpdateCustomerCommand>
{
    private readonly DbSet<CustomerReadModel> _customers;
    private readonly WriteDbContext _customersContext;
    private readonly ICustomersReadService _customersReadService;
    private readonly ICustomerFactory _customerFactory;

    public UpdateCustomerCommandHandler(ReadDbContext context, ICustomersReadService customersReadService,
        WriteDbContext customersContext, ICustomerFactory customerFactory)
    {
        _customers = context.Customers;
        _customersReadService = customersReadService;
        _customersContext = customersContext;
        _customerFactory = customerFactory;
    }


    public async Task HandleAsync(UpdateCustomerCommand command)
    {
        var (id, firstName, lastName, dateofBirth, phoneNumber, email, bankAccountNumber) = command;

        var customer = await _customers.FindAsync(command.id);
        if (customer is null)
        {
            throw new CustomerNotFoundException(command.id);
        }

        if (await _customersReadService.ExistsByEmail(email))
        {
            throw new CustomerEmailExistsException(email);
        }

        if (await _customersReadService.ExistsByNameAndBirthday(firstName, lastName, dateofBirth))
        {
            throw new CustomerNameAndBirthdayExistsException(firstName, lastName, dateofBirth);
        }

        var updatedCustomer = _customerFactory.Create(id,firstName,lastName,dateofBirth,phoneNumber,email,bankAccountNumber);

         _customersContext.Update(updatedCustomer);
        await _customersContext.SaveChangesAsync();
    }
}
