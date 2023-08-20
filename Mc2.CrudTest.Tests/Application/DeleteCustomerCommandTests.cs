using Mc2.CrudTest.Application.Commands;
using Mc2.CrudTest.Application.Commands.Handlers;
using Mc2.CrudTest.Application.Exceptions;
using Mc2.CrudTest.Application.Services;
using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.Factories;
using Mc2.CrudTest.Domain.Repositories;
using Mc2.CrudTest.Domain.ValueObjects;
using Mc2.CrudTest.Shared.Abstraction.Commands;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Shouldly;

namespace Mc2.CrudTest.Tests.Application;

public class DeleteCustomerCommandTests
{
    private ICommandHandler<DeleteCustomerCommand> _commandHandler;
    private ICustomerRepository _repository;
    private ICustomerFactory _factory;

    Task Act(DeleteCustomerCommand command)
       => _commandHandler.HandleAsync(command);

    public DeleteCustomerCommandTests()
    {
        _repository = Substitute.For<ICustomerRepository>();
        _factory = Substitute.For<ICustomerFactory>();
        _commandHandler = new DeleteCustomerCommandHandler(_repository);
    }

    [Fact]
    public async Task HandleAsync_Delete_Customer_On_Success()
    {
        var command = new CreateCustomerCommand(Guid.NewGuid(), new CustomerFirstName("Hossein"), new CustomerLastName("Moaser"),
        new CustomerDateOfBirth(new DateTime(1990, 3, 31, 12, 0, 0)), new CustomerPhoneNumber("+989308557864"),
        new CustomerEmail("moaser.hossein@gmail.com"), new CustomerBankAccountNumber("874523654"));

        var fakeCustomer = new Customer(command.id,command.firstName,command.lastName,command.dateofBirth,command.phoneNumber,
            command.email,command.bankAcountNumber);

        var createdCustomer = _factory.Create(command.id, command.firstName, command.lastName, command.dateofBirth, command.phoneNumber
            , command.email, command.bankAcountNumber).Returns(fakeCustomer);

        var deleteCommand = new DeleteCustomerCommand(command.id);

         _repository.GetCustomerByIdAsync(command.id).Returns(fakeCustomer);

        var exception = await Record.ExceptionAsync(() => Act(deleteCommand));

        exception.ShouldBeNull();
        await _repository.Received(1).DeleteCustomerAsync(Arg.Any<Customer>());
    }

    [Fact]
    public async Task HandleAsync_Throws_CustomerDoes_Not_Exists_Exception_When_Customer_With_ID_Does_Not_Exists()
    {
        var command = new CreateCustomerCommand(Guid.NewGuid(), new CustomerFirstName("Hossein"), new CustomerLastName("Moaser"),
       new CustomerDateOfBirth(new DateTime(1990, 3, 31, 12, 0, 0)), new CustomerPhoneNumber("+989308557864"),
       new CustomerEmail("moaser.hossein@gmail.com"), new CustomerBankAccountNumber("874523654"));

        var fakeCustomer = new Customer(command.id, command.firstName, command.lastName, command.dateofBirth, command.phoneNumber,
            command.email, command.bankAcountNumber);

        var createdCustomer = _factory.Create(command.id, command.firstName, command.lastName, command.dateofBirth, command.phoneNumber
            , command.email, command.bankAcountNumber).Returns(fakeCustomer);

        var deleteCommand = new DeleteCustomerCommand(command.id);

        _repository.GetCustomerByIdAsync(command.id).ReturnsNull();

        var exception = await Record.ExceptionAsync(() => Act(deleteCommand));

        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<CustomerNotFoundException>();
    }


}
