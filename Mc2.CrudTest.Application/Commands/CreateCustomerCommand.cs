using Mc2.CrudTest.Domain.ValueObjects;
using Mc2.CrudTest.Shared.Abstraction.Commands;

namespace Mc2.CrudTest.Application.Commands;

public record CreateCustomerCommand (CustomerId id, CustomerFirstName firstName, CustomerLastName lastName,
        CustomerDateOfBirth dateofBirth, CustomerPhoneNumber phoneNumber, CustomerEmail email,
        CustomerBankAccountNumber bankAcountNumber) : ICommand;
