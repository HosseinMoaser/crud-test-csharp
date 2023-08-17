using Mc2.CrudTest.Domain.Exceptions;

namespace Mc2.CrudTest.Domain.ValueObjects;

public record CustomerFirstName
{
    public string Value { get; }

	public CustomerFirstName(string value)
	{
		if(string.IsNullOrWhiteSpace(value))
		{
			throw new CustomerFirstNameException();
		}

		Value = value.Trim();
	}

    public static implicit operator string(CustomerFirstName firstName) => firstName.Value;
    public static implicit operator CustomerFirstName(string firstName) => new(firstName);
}
