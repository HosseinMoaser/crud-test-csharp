using Mc2.CrudTest.Shared.Abstraction.Exceptions;

namespace Mc2.CrudTest.Domain.Exceptions;

public class CustomerEmptyEmailException : CustomerException
{
	public CustomerEmptyEmailException():base("Email can not be empty ...!") { }
}
