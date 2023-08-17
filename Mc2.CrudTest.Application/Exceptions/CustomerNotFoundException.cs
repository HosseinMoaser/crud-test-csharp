using Mc2.CrudTest.Shared.Abstraction.Exceptions;

namespace Mc2.CrudTest.Application.Exceptions;

public class CustomerNotFoundException : CustomerException
{
	public Guid Id { get; }
	public CustomerNotFoundException(Guid id) : base($"Customer with ID '{id}' was not found") 
		=> Id = id;
}
