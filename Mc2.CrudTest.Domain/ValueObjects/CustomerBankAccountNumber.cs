using Mc2.CrudTest.Domain.Exceptions;

namespace Mc2.CrudTest.Domain.ValueObjects;

public record CustomerBankAccountNumber
{
    public string Value { get; }

    public CustomerBankAccountNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new CustomerEmptyBankAccountNumberException();
        }

        if (!value.All(char.IsDigit))
        {
            throw new CustomerInvalidBankAccountNumberException();
        }

        Value = value;
    }

    public static implicit operator string(CustomerBankAccountNumber bankAccountNumber) => bankAccountNumber.Value;
    public static explicit operator CustomerBankAccountNumber(string bankAccountNumber) => new CustomerBankAccountNumber(bankAccountNumber);

}
