using Mc2.CrudTest.Domain.Exceptions;

namespace Mc2.CrudTest.Domain.ValueObjects;

public record CustomerEmail
{
    public string Value { get; }

	public CustomerEmail(string value)
	{
        if (string.IsNullOrWhiteSpace(value))
            throw new CustomerEmptyEmailException();

        try
        {
            var addr = new System.Net.Mail.MailAddress(value);
            if (addr.Address != value)
                throw new CustomerInvalidEmailException();
        }
        catch
        {
            throw new CustomerInvalidEmailException();
        }

        Value = value;
    }

    public static implicit operator string(CustomerEmail email) => email.Value;
    public static explicit operator CustomerEmail(string email) => new CustomerEmail(email);

}
