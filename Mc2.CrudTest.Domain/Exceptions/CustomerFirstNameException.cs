using Mc2.CrudTest.Shared.Abstraction.Exceptions;

namespace Mc2.CrudTest.Domain.Exceptions;

public class CustomerFirstNameException : CustomerException
{
	public CustomerFirstNameException() : base("Customer first name is required...!") { }
}
