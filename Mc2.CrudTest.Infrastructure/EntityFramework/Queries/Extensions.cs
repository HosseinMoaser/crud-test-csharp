using Mc2.CrudTest.Application.DTOs;
using Mc2.CrudTest.Infrastructure.EntityFramework.Models;

namespace Mc2.CrudTest.Infrastructure.EntityFramework.Queries;

public static class Extensions
{
    public static CustomerDto MapToDto(this CustomerReadModel readModel)
    {
        return new CustomerDto 
        {
            Id = readModel.Id,
            FirstName= readModel.FirstName,
            LastName= readModel.LastName,
            DateofBirth= readModel.DateofBirth,
            Email= readModel.Email,
            PhoneNumber= readModel.PhoneNumber,
            BankAccountNumber = readModel.BankAccountNumber
        };
    }
}
