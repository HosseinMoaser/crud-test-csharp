using Mc2.CrudTest.Application.Exceptions;
using Mc2.CrudTest.Application.Services;
using Mc2.CrudTest.Domain.Factories;
using Mc2.CrudTest.Domain.Repositories;
using Mc2.CrudTest.Shared.Abstraction.Commands;

namespace Mc2.CrudTest.Application.Commands.Handlers;

public sealed class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ICustomerFactory _customerFactory;
    private readonly ICustomersReadService _customersReadService;
    public CreateCustomerCommandHandler(ICustomerRepository customerRepository, ICustomerFactory customerFactory, 
        ICustomersReadService customersReadService)
    {
        _customerRepository = customerRepository;
        _customerFactory = customerFactory;
        _customersReadService = customersReadService;
    }

    public async Task HandleAsync(CreateCustomerCommand command)
    {
        var (id, firstName, lastName, dateofBirth, phoneNumber, email, bankAccountNumber) = command;

        if(await _customersReadService.ExistsByEmail(email))
        {
            throw new CustomerEmailExistsException(email);
        }

        if(await _customersReadService.ExistsByNameAndBirthday(firstName, lastName, dateofBirth))
        {
            throw new CustomerNameAndBirthdayExistsException(firstName,lastName,dateofBirth);
        }

        var customer = _customerFactory.Create(id, firstName, lastName, dateofBirth,  phoneNumber, email, bankAccountNumber);

        await _customerRepository.AddCustomerAsync(customer);
    }
}
