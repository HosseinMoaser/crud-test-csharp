using Mc2.CrudTest.Domain.Exceptions;

namespace Mc2.CrudTest.Domain.ValueObjects;

public record CustomerDateOfBirth
{
    public DateTime Value { get; }

	public CustomerDateOfBirth(DateTime value)
	{
		if(value >= DateTime.Today)
		{
			throw new CustomerDateOfBirthException();
		}

		Value = value;
	}

    public static implicit operator DateTime(CustomerDateOfBirth dateOfBirth) => dateOfBirth.Value;
    public static explicit operator CustomerDateOfBirth(DateTime dateOfBirth) => new CustomerDateOfBirth(dateOfBirth);
}
