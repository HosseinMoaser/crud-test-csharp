using Mc2.CrudTest.Shared.Abstraction.Exceptions;

namespace Mc2.CrudTest.Domain.Exceptions;

public class CustomerEmptyBankAccountNumberException : CustomerException
{
	public CustomerEmptyBankAccountNumberException() : base("Bank account number can not be empty...!") { }
}
