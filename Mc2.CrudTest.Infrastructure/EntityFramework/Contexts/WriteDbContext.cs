using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Infrastructure.EntityFramework.Config;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infrastructure.EntityFramework.Contexts;

public class WriteDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }

	public WriteDbContext(DbContextOptions<WriteDbContext> options) : base (options)
	{

	}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Customers");

        var configuration = new WriteConfiguration();
        modelBuilder.ApplyConfiguration<Customer>(configuration);
    }
}
