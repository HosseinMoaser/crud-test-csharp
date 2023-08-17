using Mc2.CrudTest.Domain.Factories;
using Mc2.CrudTest.Domain.Repositories;
using Mc2.CrudTest.Shared.Abstraction.Commands;

namespace Mc2.CrudTest.Application.Commands.Handlers;

public sealed class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ICustomerFactory _customerFactory;

    public CreateCustomerCommandHandler(ICustomerRepository customerRepository, ICustomerFactory customerFactory)
    {
        _customerRepository = customerRepository;
        _customerFactory = customerFactory;
    }

    public async Task HandleAsync(CreateCustomerCommand command)
    {
        var (id, firstName, lastName, dateofBirth, phoneNumber, email, bankAccountNumber) = command;

        var customer = _customerFactory.Create(id, firstName, lastName, dateofBirth,  phoneNumber, email, bankAccountNumber);

        await _customerRepository.AddCustomerAsync(customer);
    }
}
