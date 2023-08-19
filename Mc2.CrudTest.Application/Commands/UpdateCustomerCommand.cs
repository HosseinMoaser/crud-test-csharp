using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.ValueObjects;
using Mc2.CrudTest.Shared.Abstraction.Commands;

namespace Mc2.CrudTest.Application.Commands;

public record UpdateCustomerCommand(Guid id,CustomerFirstName firstName, CustomerLastName lastName,
        CustomerDateOfBirth dateofBirth, CustomerPhoneNumber phoneNumber, CustomerEmail email,
        CustomerBankAccountNumber bankAcountNumber) : ICommand;