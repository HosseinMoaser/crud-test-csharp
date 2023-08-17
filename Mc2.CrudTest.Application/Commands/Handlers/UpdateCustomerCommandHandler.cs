using Mc2.CrudTest.Application.Exceptions;
using Mc2.CrudTest.Domain.Repositories;
using Mc2.CrudTest.Shared.Abstraction.Commands;

namespace Mc2.CrudTest.Application.Commands.Handlers;

public sealed class UpdateCustomerCommandHandler : ICommandHandler<UpdateCustomerCommand>
{
    private readonly ICustomerRepository _customerRepository;

    public UpdateCustomerCommandHandler(ICustomerRepository customerRepository) 
        =>  _customerRepository = customerRepository;
    

    public async Task HandleAsync(UpdateCustomerCommand command)
    {
        var customer = await _customerRepository.GetCustomerByIdAsync(command.id);
        if(customer is null)
        {
            throw new CustomerNotFoundException(command.id);
        }

        await _customerRepository.UpdateCustomerAsync(customer);
    }
}
