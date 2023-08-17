using Mc2.CrudTest.Shared.Abstraction.Exceptions;

namespace Mc2.CrudTest.Domain.Exceptions;

public class CustomerLastNameException : CustomerException
{
	public CustomerLastNameException() : base("Customer last name is required...!") { }
}
