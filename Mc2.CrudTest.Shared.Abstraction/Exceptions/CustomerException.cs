namespace Mc2.CrudTest.Shared.Abstraction.Exceptions;

public abstract class CustomerException : Exception
{
	protected CustomerException(string message) : base(message)
	{
			
	}
}
