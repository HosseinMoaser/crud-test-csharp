using Mc2.CrudTest.Shared.Abstraction.Exceptions;

namespace Mc2.CrudTest.Domain.Exceptions;

public class CustomerPhoneNumberException : CustomerException
{
	public CustomerPhoneNumberException() : base ("Phone Number is  not valid...!") { }
}
