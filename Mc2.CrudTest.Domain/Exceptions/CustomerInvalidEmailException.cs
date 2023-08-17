using Mc2.CrudTest.Shared.Abstraction.Exceptions;

namespace Mc2.CrudTest.Domain.Exceptions;

public class CustomerInvalidEmailException : CustomerException
{
	public CustomerInvalidEmailException() : base ("Email is not in correct format...!") { }
}
