using Mc2.CrudTest.Shared.Abstraction.Exceptions;

namespace Mc2.CrudTest.Application.Exceptions;

public class CustomerEmailExistsException : CustomerException
{
    public string Email { get; set; }

	public CustomerEmailExistsException(string email) : base($"Customer with the email '{email}' already exists...!")
	{
		Email = email;
	}
}
