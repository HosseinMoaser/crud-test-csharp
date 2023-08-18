namespace Mc2.CrudTest.Infrastructure.EntityFramework.Models;

public class CustomerReadModel
{
    public Guid Id { get; set; }
    public int Version { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateofBirth { get; set; }
    public string Email { get; set; }
}
