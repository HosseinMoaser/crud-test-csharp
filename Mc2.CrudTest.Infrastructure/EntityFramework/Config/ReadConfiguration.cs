using Mc2.CrudTest.Infrastructure.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mc2.CrudTest.Infrastructure.EntityFramework.Config;

internal sealed class ReadConfiguration : IEntityTypeConfiguration<CustomerReadModel>
{
    public void Configure(EntityTypeBuilder<CustomerReadModel> builder)
    {
        builder.ToTable("Customers");
        builder.HasKey(pl => pl.Id);
        builder.Property(pl => pl.FirstName);
        builder.Property(pl => pl.LastName);
        builder.Property(pl => pl.DateofBirth);
        builder.Property(pl => pl.Email);
    }
}
