using Mc2.CrudTest.Shared.Abstraction.Exceptions;

namespace Mc2.CrudTest.Domain.Exceptions;

public class CustomerDateOfBirthException : CustomerException
{
	public CustomerDateOfBirthException() : base("Date of Birth can not be in the future...!") { }
}
