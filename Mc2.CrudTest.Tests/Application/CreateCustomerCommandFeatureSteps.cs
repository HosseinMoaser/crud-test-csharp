using Mc2.CrudTest.Application.Commands;
using Mc2.CrudTest.Application.Commands.Handlers;
using Mc2.CrudTest.Application.Services;
using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.Factories;
using Mc2.CrudTest.Domain.Repositories;
using Mc2.CrudTest.Domain.ValueObjects;
using Mc2.CrudTest.Shared.Abstraction.Commands;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Shouldly;
using TechTalk.SpecFlow;

namespace Mc2.CrudTest.Tests.Application;

[Binding]
public class CreateCustomerCommandFeatureSteps
{
    private ICommandHandler<CreateCustomerCommand> _commandHandler;
    private ICustomerRepository _repository;
    private ICustomersReadService _readService;
    private ICustomerFactory _factory;
    private Customer createdCustomer;
    private Exception exception;
    private CreateCustomerCommand command;


    Task Act(CreateCustomerCommand command)
       => _commandHandler.HandleAsync(command);

    public CreateCustomerCommandFeatureSteps()
    {
        _repository = Substitute.For<ICustomerRepository>();
        _readService = Substitute.For<ICustomersReadService>();
        _factory = Substitute.For<ICustomerFactory>();
        _commandHandler = new CreateCustomerCommandHandler(_repository, _factory, _readService);
    }

    [Given(@"that we have a valid inputs for customer factory")]
    public void GivenThatWeHaveAValidInputsForCustomerFactory()
    {
        command = new CreateCustomerCommand(Guid.NewGuid(), new CustomerFirstName("Hossein"), new CustomerLastName("Moaser"),
            new CustomerDateOfBirth(new DateTime(1990, 3, 31, 12, 0, 0)), new CustomerPhoneNumber("+989308557864"),
            new CustomerEmail("moaser.hossein@gmail.com"), new CustomerBankAccountNumber("874523654"));

        createdCustomer = new Customer(command.id, command.firstName, command.lastName, command.dateofBirth, command.phoneNumber,
            command.email, command.bankAcountNumber);
    }

    [Given(@"created customer  does not exists in a database")]
    public void GivenCreatedCustomerDoesNotExistsInADatabase()
    {
        _readService.ExistsByEmail(command.email).Returns(false);
        _readService.ExistsByNameAndBirthday(command.firstName.Value, command.lastName.Value, command.dateofBirth.Value).Returns(false);
        _repository.GetCustomerByIdAsync(command.id).ReturnsNull();
    }

    [When(@"I call HandleAsync method of command hanler")]
    public async void WhenICallHandleAsyncMethodOfCommandHanler()
    {
        exception = await Record.ExceptionAsync(() => Act(command));
    }

    [Then(@"created customer should be added to the database")]
    public async void ThenCreatedCustomerShouldBeAddedToTheDatabase()
    {
        await _repository.Received(1).AddCustomerAsync(Arg.Any<Customer>());
    }

    [Then(@"no exception should be thrown")]
    public void ThenNoExceptionShouldBeThrown()
    {
        exception.ShouldBeNull();
    }

}
