using Mc2.CrudTest.Application.Commands;
using Mc2.CrudTest.Application.Commands.Handlers;
using Mc2.CrudTest.Application.Exceptions;
using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.Factories;
using Mc2.CrudTest.Domain.Repositories;
using Mc2.CrudTest.Domain.ValueObjects;
using Mc2.CrudTest.Shared.Abstraction.Commands;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Shouldly;
using TechTalk.SpecFlow;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Mc2.CrudTest.Tests.Application;

[Binding]
public class DeleteCustomerCommandFeatureSteps
{
    private ICommandHandler<DeleteCustomerCommand> _commandHandler;
    private ICustomerRepository _repository;
    private CreateCustomerCommand command;
    private DeleteCustomerCommand deleteCommand;
    private Customer createdCustomer;
    private Exception exception;


    Task Act(DeleteCustomerCommand command)
       => _commandHandler.HandleAsync(command);

    public DeleteCustomerCommandFeatureSteps()
    {
        _repository = Substitute.For<ICustomerRepository>();
        _commandHandler = new DeleteCustomerCommandHandler(_repository);
    }

    #region Deleting existing customer with ID scenario 
    [Given(@"that a customer exists in database")]
    public void GivenThatACustomerExistsInDatabase()
    {
        command = new CreateCustomerCommand(Guid.NewGuid(), new CustomerFirstName("Hossein"), new CustomerLastName("Moaser"),
            new CustomerDateOfBirth(new DateTime(1990, 3, 31, 12, 0, 0)), new CustomerPhoneNumber("+989308557864"),
        new CustomerEmail("moaser.hossein@gmail.com"), new CustomerBankAccountNumber("874523654"));

        createdCustomer = new Customer(command.id, command.firstName, command.lastName, command.dateofBirth, command.phoneNumber,
        command.email, command.bankAcountNumber);

         deleteCommand = new DeleteCustomerCommand(command.id);
        _repository.GetCustomerByIdAsync(command.id).Returns(createdCustomer);
    }
    [When(@"I call HandleAsync method of delete command handler")]
    public void WhenICallHandleAsyncMethodOfDeleteCommandHandler()
    {
        exception =  Record.ExceptionAsync(() => Act(deleteCommand)).Result;
    }

    [Then(@"customer information should be deleted from database")]
    public async void ThenCustomerInformationShouldBeDeletedFromDatabase()
    {
        await _repository.Received(1).DeleteCustomerAsync(Arg.Any<Customer>());
    }

    [Then(@"no exception should be thrown while data is deleting")]
    public void ThenNoExceptionShouldBeThrownWhileDataIsDeleting()
    {
        exception.ShouldBeNull();
    }

    #endregion

    [Given(@"that a customer does not exists in database")]
    public void GivenThatACustomerDoesNotExistsInDatabase()
    {
        command = new CreateCustomerCommand(Guid.NewGuid(), new CustomerFirstName("Hossein"), new CustomerLastName("Moaser"),
            new CustomerDateOfBirth(new DateTime(1990, 3, 31, 12, 0, 0)), new CustomerPhoneNumber("+989308557864"),
        new CustomerEmail("moaser.hossein@gmail.com"), new CustomerBankAccountNumber("874523654"));

        createdCustomer = new Customer(command.id, command.firstName, command.lastName, command.dateofBirth, command.phoneNumber,
        command.email, command.bankAcountNumber);

        deleteCommand = new DeleteCustomerCommand(command.id);
        _repository.GetCustomerByIdAsync(command.id).ReturnsNull();
    }

    [Then(@"exception should be thrown")]
    public void ThenExceptionShouldBeThrown()
    {
        exception.ShouldNotBeNull();
    }

    [Then(@"type of exception should be CustomerNotFoundException")]
    public void ThenTypeOfExceptionShouldBeCustomerNotFoundException()
    {
        exception.ShouldBeOfType<CustomerNotFoundException>();
    }


}
