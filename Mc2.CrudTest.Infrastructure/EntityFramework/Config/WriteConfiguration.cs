using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.ValueObjects;
using Mc2.CrudTest.Infrastructure.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Mc2.CrudTest.Infrastructure.EntityFramework.Config;

internal sealed class WriteConfiguration : IEntityTypeConfiguration<Customer>
{

    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(pl => pl.Id);

        #region Conversions
        var customerFirstNameConverter = new ValueConverter<CustomerFirstName, string>(cfn => cfn.Value,
                cfn => new CustomerFirstName(cfn));

        var customerLastNameConverter = new ValueConverter<CustomerLastName, string>(cln => cln.Value,
                cln => new CustomerLastName(cln));

        var customerDateofBirthConverter = new ValueConverter<CustomerDateOfBirth, DateTime>(cdof => cdof.Value,
                cdof => new CustomerDateOfBirth(cdof));

        var customerPhoneNumberConverter = new ValueConverter<CustomerPhoneNumber, string>(cpn => cpn.Value,
                cpn => new CustomerPhoneNumber(cpn));

        var customerEmailConverter = new ValueConverter<CustomerEmail, string>(ce => ce.Value,
                 ce => new CustomerEmail(ce));

        var customerBankAccountNumberConverter = new ValueConverter<CustomerBankAccountNumber, string>(cban => cban.Value,
                 cban => new CustomerBankAccountNumber(cban));

        #endregion

        builder.Property(pl => pl.Id)
                .HasConversion(id => id.Value, id => new CustomerId(id));

        builder
                .Property(typeof(CustomerFirstName), "_firstName")
                .HasConversion(customerFirstNameConverter)
                .HasColumnName("FirstName");

        builder
                .Property(typeof(CustomerLastName), "_lastName")
                .HasConversion(customerLastNameConverter)
                .HasColumnName("LastName");

        builder
                .Property(typeof(CustomerDateOfBirth), "_dateofBirth")
                .HasConversion(customerDateofBirthConverter)
                .HasColumnName("DateofBirth");

        builder
                .Property(typeof(CustomerPhoneNumber), "_phoneNumber")
                .HasConversion(customerPhoneNumberConverter)
                .HasColumnName("PhoneNumber")
                .HasColumnType("varchar(20)");

        builder
                .Property(typeof(CustomerEmail), "_email")
                .HasConversion(customerEmailConverter)
                .HasColumnName("Email");

        builder
                .Property(typeof(CustomerBankAccountNumber), "_bankAccountNumber")
                .HasConversion(customerBankAccountNumberConverter)
                .HasColumnName("BankAccountNumber");

        builder.ToTable("Customers");
    }
}
