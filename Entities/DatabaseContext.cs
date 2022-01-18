using Microsoft.EntityFrameworkCore;
using WebAPI.Entities;

namespace WebAPI
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
		{
		}

		public DbSet<Employee> Employees { get; set; }
		public DbSet<Company> Companies { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Company>()
				.Property(c => c.Name)
				.IsRequired();
			modelBuilder.Entity<Company>()
				.Property(c => c.EstablishmentYear)
				.IsRequired();

			modelBuilder.Entity<Employee>()
				.Property(e => e.FirstName)
				.IsRequired();
			modelBuilder.Entity<Employee>()
				.Property(e => e.LastName)
				.IsRequired();
			modelBuilder.Entity<Employee>()
				.Property(e => e.DateOfBirth)
				.IsRequired();
			modelBuilder.Entity<Employee>()
				.Property(e => e.JobTitle)
				.IsRequired();
			modelBuilder.Entity<Employee>()
				.Property(e => e.JobTitle)
				.HasConversion<string>();
		}
	}
}
