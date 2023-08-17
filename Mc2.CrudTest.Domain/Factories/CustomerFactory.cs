using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.ValueObjects;

namespace Mc2.CrudTest.Domain.Factories;

public class CustomerFactory : ICustomerFactory
{
    public Customer Create(CustomerId id, CustomerFirstName firstName, CustomerLastName lastName,
        CustomerDateOfBirth dateofBirth, CustomerPhoneNumber phoneNumber, CustomerEmail email,
        CustomerBankAccountNumber bankAcountNumber)
        => new(id,firstName,lastName,dateofBirth,phoneNumber,email,bankAcountNumber);
}
