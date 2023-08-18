namespace Mc2.CrudTest.Application.Services;

public interface ICustomersReadService
{
    Task<bool> ExistsByNameAndBirthday(string firstName, string lastName, DateTime dateofBirth);
    Task<bool> ExistsByEmail(string email);
}
