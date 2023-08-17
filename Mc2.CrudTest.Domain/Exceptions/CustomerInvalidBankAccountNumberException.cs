using Mc2.CrudTest.Shared.Abstraction.Exceptions;

namespace Mc2.CrudTest.Domain.Exceptions;

public class CustomerInvalidBankAccountNumberException : CustomerException
{
	public CustomerInvalidBankAccountNumberException() : base ("Bank account number is not valid...!") { }
}
