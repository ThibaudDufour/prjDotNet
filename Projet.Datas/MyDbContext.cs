using Microsoft.EntityFrameworkCore;
using Projet.Datas.Entities;

namespace Projet.Datas
{
    public class MyDbContext : DbContext
	{
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Anomaly> Anomalies { get; set; }
        public DbSet<BusinessCustomer> BusinessCustomers { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<PrivateCustomer> PrivateCustomers { get; set; }
		public DbSet<Transaction> Transactions { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = deProjetHN; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<PrivateCustomer>()
				.Property(pc => pc.Sex)
				.HasConversion<string>();

			modelBuilder.Entity<Transaction>()
				.Property(t => t.TransactionType)
				.HasConversion<string>();

			modelBuilder.Entity<Customer>().UseTptMappingStrategy();
			modelBuilder.Entity<BusinessCustomer>().ToTable("BusinessCustomers");
			modelBuilder.Entity<PrivateCustomer>().ToTable("PrivateCustomers");

			modelBuilder.Entity<Transaction>().UseTptMappingStrategy();
			modelBuilder.Entity<Anomaly>().ToTable("Anomalies");
		}
	}
}
