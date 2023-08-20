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
using Shouldly;

namespace Mc2.CrudTest.Tests.Application;

public class CreateCustomerCommandTests
{
    private ICommandHandler<CreateCustomerCommand> _commandHandler;
    private ICustomerRepository _repository;
    private ICustomersReadService _readService;
    private ICustomerFactory _factory;

    Task Act(CreateCustomerCommand command)
       => _commandHandler.HandleAsync(command);

    public CreateCustomerCommandTests()
    {
        _repository = Substitute.For<ICustomerRepository>();
        _readService = Substitute.For<ICustomersReadService>();
        _factory = Substitute.For<ICustomerFactory>();
        _commandHandler = new CreateCustomerCommandHandler(_repository, _factory, _readService);
    }

    [Fact]
    public async Task HandleAsync_Calls_Repository_On_Success()
    {
        var command = new CreateCustomerCommand(Guid.NewGuid(), new CustomerFirstName("Hossein"), new CustomerLastName("Moaser"),
        new CustomerDateOfBirth(new DateTime(1990, 3, 31, 12, 0, 0)), new CustomerPhoneNumber("+989308557864"),
        new CustomerEmail("moaser.hossein@gmail.com"), new CustomerBankAccountNumber("874523654"));

        _readService.ExistsByEmail(command.email).Returns(false);
        _readService.ExistsByNameAndBirthday(command.firstName.Value, command.lastName.Value, command.dateofBirth.Value).Returns(false);
        var createdCustomer = _factory.Create(command.id, command.firstName, command.lastName, command.dateofBirth, command.phoneNumber
            , command.email, command.bankAcountNumber).Returns(default(Customer));

        var exception = await Record.ExceptionAsync(() => Act(command));

        exception.ShouldBeNull();
        await _repository.Received(1).AddCustomerAsync(Arg.Any<Customer>());
    }

    [Fact]
    public async Task HandleAsync_Throws_CustomerEmailAlreadyExistsException_When_Customer_With_Same_Email_Already_Exists()
    {
        var command = new CreateCustomerCommand(Guid.NewGuid(), new CustomerFirstName("Hossein"), new CustomerLastName("Moaser"),
        new CustomerDateOfBirth(new DateTime(1990, 3, 31, 12, 0, 0)), new CustomerPhoneNumber("+989308557864"),
        new CustomerEmail("moaser.hossein@gmail.com"), new CustomerBankAccountNumber("874523654"));
        _readService.ExistsByEmail(command.email).Returns(true);

        var exception = await Record.ExceptionAsync(() => Act(command));

        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<CustomerEmailExistsException>();
    }

    [Fact]
    public async Task HandleAsync_Throws_CustomerNameAndEmailExistsException_When_Customer_With_Same_Name_And_Birthday_Already_Exists()
    {
        var command = new CreateCustomerCommand(Guid.NewGuid(), new CustomerFirstName("Hossein"), new CustomerLastName("Moaser"),
        new CustomerDateOfBirth(new DateTime(1990, 3, 31, 12, 0, 0)), new CustomerPhoneNumber("+989308557864"),
        new CustomerEmail("moaser.hossein@gmail.com"), new CustomerBankAccountNumber("874523654"));
        _readService.ExistsByNameAndBirthday(command.firstName, command.lastName, command.dateofBirth).Returns(true);

        var exception = await Record.ExceptionAsync(() => Act(command));

        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<CustomerNameAndBirthdayExistsException>();
    }
}
