using Mc2.CrudTest.Shared.Abstraction.Exceptions;

namespace Mc2.CrudTest.Domain.Exceptions;

public class CustomerIdException : CustomerException
{
	public CustomerIdException() : base("Customer Id can not be empty...!") { }
}
