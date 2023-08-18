using Mc2.CrudTest.Shared.Abstraction.Exceptions;

namespace Mc2.CrudTest.Application.Exceptions;

public class CustomerNameAndBirthdayExistsException : CustomerException
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateofBirth { get; set; }

    public CustomerNameAndBirthdayExistsException(string firstName, string lastName, DateTime dateofBirth) : 
        base($"Customer with name '{firstName}' '{lastName}' and with birthday '{dateofBirth}' is already exists...!")
    {
        FirstName = firstName;
        LastName = lastName;
        DateofBirth = dateofBirth;
    }
}
