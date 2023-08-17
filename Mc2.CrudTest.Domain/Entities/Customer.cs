using Mc2.CrudTest.Domain.ValueObjects;
using Mc2.CrudTest.Shared.Abstraction.Domain;

namespace Mc2.CrudTest.Domain.Entities;

public class Customer : AggregateRoot<CustomerId>
{
    public CustomerId Id { get; private  set; }
    private CustomerFirstName _firstName;
    private CustomerLastName _lastName;
    private CustomerDateOfBirth _dateofBirth;
    private CustomerPhoneNumber _phoneNumber;
    private CustomerEmail _email;
    private CustomerBankAccountNumber _bankAcountNumber;

    public Customer()
    {

    }

    internal Customer(CustomerId id, CustomerFirstName firstName, CustomerLastName lastName, 
        CustomerDateOfBirth dateofBirth,  CustomerPhoneNumber phoneNumber, 
        CustomerEmail email, CustomerBankAccountNumber bankAcountNumber)
    {
         Id = id;
        _firstName = firstName;
        _lastName = lastName;
        _dateofBirth = dateofBirth;
        _phoneNumber = phoneNumber;
        _email = email;
        _bankAcountNumber = bankAcountNumber;
    }
}
