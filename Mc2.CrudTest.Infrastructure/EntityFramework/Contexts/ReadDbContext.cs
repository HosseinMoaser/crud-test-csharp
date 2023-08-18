using Mc2.CrudTest.Infrastructure.EntityFramework.Config;
using Mc2.CrudTest.Infrastructure.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infrastructure.EntityFramework.Contexts;

public class ReadDbContext : DbContext
{
    public DbSet<CustomerReadModel> Customers { get; set; }

	public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
	{

	}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Customers");
        var configuration = new ReadConfiguration();
        modelBuilder.ApplyConfiguration<CustomerReadModel>(configuration);
    }
}
