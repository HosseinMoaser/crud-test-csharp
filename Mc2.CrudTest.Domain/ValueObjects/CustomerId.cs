using Mc2.CrudTest.Domain.Exceptions;

namespace Mc2.CrudTest.Domain.ValueObjects;

public record CustomerId
{
    public Guid Value { get; }

	public CustomerId(Guid value)
	{
		if(value == Guid.Empty)
		{
			throw new CustomerIdException();
		}

		Value = value;
	}

	public static implicit operator Guid(CustomerId id) => id.Value;
	public static implicit operator CustomerId(Guid id) => new(id);
}
