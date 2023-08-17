using Mc2.CrudTest.Domain.Exceptions;

namespace Mc2.CrudTest.Domain.ValueObjects;

public record CustomerLastName
{
    public string Value { get;}

	public CustomerLastName(string value)
	{
		if(string.IsNullOrWhiteSpace(value))
		{
			throw new CustomerLastNameException();
		}

		Value = value;
	}

    public static implicit operator string(CustomerLastName lastName) => lastName.Value;
    public static implicit operator CustomerLastName(string lastName) => new(lastName);
}
