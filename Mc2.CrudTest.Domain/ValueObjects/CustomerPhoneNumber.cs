using Mc2.CrudTest.Domain.Exceptions;
using PhoneNumbers;

namespace Mc2.CrudTest.Domain.ValueObjects;

public record CustomerPhoneNumber
{
    public string Value { get; }

	public CustomerPhoneNumber(string value)
	{
        var phoneNumberUtil = PhoneNumberUtil.GetInstance();
        try
        {
            var phoneNumber = phoneNumberUtil.Parse(value, null);
            if (!phoneNumberUtil.IsValidNumber(phoneNumber))
                throw new CustomerPhoneNumberException();
        }
        catch (NumberParseException)
        {
            throw new CustomerPhoneNumberException();
        }
        Value = value;
	}

    public static implicit operator string(CustomerPhoneNumber phoneNumber) => phoneNumber.Value;
    public static explicit operator CustomerPhoneNumber(string phoneNumber) => new CustomerPhoneNumber(phoneNumber);

}
