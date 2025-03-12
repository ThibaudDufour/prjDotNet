using Microsoft.EntityFrameworkCore;
using Projet.Datas.Entities;
using Projet.Datas.Entities.Enum;
using Projet.Datas.Entities.Interfaces;

namespace Projet.Datas
{
	public class MyDbContext : DbContext
	{
		public DbSet<Account> Accounts { get; set; }
		public DbSet<Anomaly> Anomalies { get; set; }
		public DbSet<BankCard> BankCards { get; set; }
		public DbSet<BusinessCustomer> BusinessCustomers { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<PrivateCustomer> PrivateCustomers { get; set; }
		public DbSet<Transaction> Transactions { get; set; }
		public DbSet<LoginUser> LoginUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = dbProjetHN; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<BankCard>()
				.HasKey(bc => new { bc.CardNumber, bc.AccountNumber });

			modelBuilder.Entity<Account>()
				.HasMany(a => a.Owners)
				.WithMany(c => c.Accounts)
				.UsingEntity<Dictionary<string, object>>(
					"AccountOwners",
					ao => ao.HasOne<Customer>().WithMany().HasForeignKey("OwnersId"),
					ao => ao.HasOne<Account>().WithMany().HasForeignKey("AccountsAccountNumber"),
					ao =>
					{
						ao.HasKey("OwnersId", "AccountsAccountNumber");
						ao.ToTable("AccountOwners");
					}
				);

			modelBuilder.Entity<Anomaly>()
				.Property(t => t.TransactionType)
				.HasConversion<string>();

			modelBuilder.Entity<Anomaly>()
				.Property(t => t.Currency)
				.HasConversion<string>();

			modelBuilder.Entity<BusinessCustomer>()
				.Property(bc => bc.LegalStatus)
				.HasConversion<string>();

			modelBuilder.Entity<PrivateCustomer>()
				.Property(pc => pc.Sex)
				.HasConversion<string>();

			modelBuilder.Entity<Transaction>()
				.Property(t => t.TransactionType)
				.HasConversion<string>();

			modelBuilder.Entity<Transaction>()
				.Property(t => t.Currency)
				.HasConversion<string>();

			modelBuilder.Entity<Customer>().UseTptMappingStrategy();
			modelBuilder.Entity<BusinessCustomer>().ToTable("BusinessCustomers");
			modelBuilder.Entity<PrivateCustomer>().ToTable("PrivateCustomers");

			modelBuilder.Entity<Transaction>().UseTpcMappingStrategy();
			modelBuilder.Entity<Anomaly>().ToTable("Anomalies");
			modelBuilder.Entity<Transaction>().ToTable("Transactions");

			modelBuilder.Entity<PrivateCustomer>()
				.HasData(
				   new PrivateCustomer { 
					   Id = 1, 
					   Name = "BETY", 
					   Label = "12, rue des Oliviers", 
					   City = "CRETEIL", 
					   PostalCode = "94000",
					   Email = "bety@gmail.com", 
					   FirstName = "Daniel", 
					   Sex = EnumSexe.Male,
					   DateBirth = new DateTime(1985, 11, 12) 
				   },
				   new PrivateCustomer { 
					   Id = 3, 
					   Name = "BODIN",
					   Label = "10, rue des Olivies", 
					   AdditionalInfo = "Etage 2", 
					   City = "VINCENNES", 
					   PostalCode = "94300", 
					   Email = "bodin@gmail.com", 
					   FirstName = "Justin", 
					   Sex = EnumSexe.Male, 
					   DateBirth = new DateTime(1965, 5, 5) 
				   },
				   new PrivateCustomer { 
					   Id = 5,
					   Name = "BERRIS", 
					   Label = "15, rue de la République", 
					   City = "FONTENAY SOUS BOIS", 
					   PostalCode = "94120", 
					   Email = "berris@gmail.com", 
					   FirstName = "Karine", 
					   Sex = EnumSexe.Female, 
					   DateBirth = new DateTime(1977, 6, 6) 
				   },
				   new PrivateCustomer { 
					   Id = 7, 
					   Name = "ABENIR", 
					   Label = "25, rue de la Paix", 
					   City = "LA DEFENSE", 
					   PostalCode = "92100", 
					   Email = "abenir@gmail.com", 
					   FirstName = "Alexandra", 
					   Sex = EnumSexe.Female, 
					   DateBirth = new DateTime(1977, 4, 12) 
				   },
				   new PrivateCustomer { 
					   Id = 9, 
					   Name = "BENSAID", 
					   Label = "3, avenue des Parcs", 
					   City = "ROISSY EN FRANCE", 
					   PostalCode = "93500", 
					   Email = "bensaid@gmail.com", 
					   FirstName = "Georgia", 
					   Sex = EnumSexe.Female, 
					   DateBirth = new DateTime(1976, 4, 16) 
				   },
				   new PrivateCustomer { 
					   Id = 11, 
					   Name = "ABABOU", 
					   Label = "3, rue Lecourbe",
					   City = "BAGNOLET", 
					   PostalCode = "93200", 
					   Email = "ababou@gmail.com", 
					   FirstName = "Teddy", 
					   Sex = EnumSexe.Male, 
					   DateBirth = new DateTime(1970, 10, 10)
				   }
			   );

			modelBuilder.Entity<BusinessCustomer>()
				.HasData(
					new BusinessCustomer { 
						Id = 2, 
						Name = "AXA", 
						Label = "125, rue LaFayette",
						AdditionalInfo = "Digicode 1432", 
						City = "FONTENAY SOUS BOIS", 
						PostalCode = "94120", 
						Email = "info@axa.fr", 
						Siret = "12548795641122", 
						LegalStatus = EnumLegalStatus.SARL, 
						SiegeLabel = "125, rue LaFayette", 
						SiegeComplement = "Digicode 1432", 
						SiegeCity = "FONTENAY SOUS BOIS", 
						SiegePostalCode = "94120" 
					},
					new BusinessCustomer {
						Id = 4, Name = "PAUL",
						Label = "36, quai des Orfèvres",
						City = "ROISSY EN FRANCE", 
						PostalCode = "93500", 
						Email = "info@paul.fr", 
						Siret = "87459564455444", 
						LegalStatus = EnumLegalStatus.EURL, 
						SiegeLabel = "10, esplanade de la Défense", 
						SiegeCity = "LA DEFENSE", 
						SiegePostalCode = "92060" 
					},
					new BusinessCustomer { 
						Id = 6, 
						Name = "PRIMARK",
						Label = "32, rue E. Renan",
						AdditionalInfo = "Bat. C", 
						City = "PARIS", 
						PostalCode = "75002", 
						Email = "contact@primark.fr", 
						Siret = "08755897458455", 
						LegalStatus = EnumLegalStatus.SARL, 
						SiegeLabel = "32, rue E. Renan", 
						SiegeComplement = "Bat. C", 
						SiegeCity = "PARIS", 
						SiegePostalCode = "75002" 
					},
					new BusinessCustomer { 
						Id = 8, 
						Name = "ZARA", 
						Label = "23, av P. Valery", 
						City = "LA DEFENSE", 
						PostalCode = "92100", 
						Email = "info@zara.fr", 
						Siret = "65895874587854", 
						LegalStatus = EnumLegalStatus.SA, 
						SiegeLabel = "24, esplanade de la Défense", 
						SiegeComplement = "Tour Franklin", 
						SiegeCity = "LA DEFENSE", 
						SiegePostalCode = "92060" 
					},
					new BusinessCustomer { 
						Id = 10, 
						Name = "LEONIDAS", 
						Label = "15, Place de la Bastille",
						AdditionalInfo = "Fond de Cour",
						City = "PARIS", 
						PostalCode = "75003", 
						Email = "contact@leonidas.fr", 
						Siret = "91235987456832", 
						LegalStatus = EnumLegalStatus.SAS, 
						SiegeLabel = "10, rue de la Paix", 
						SiegeCity = "PARIS", 
						SiegePostalCode = "75008" 
					}
				);

			Account a1 = new Account { AccountNumber = "FR294067299996", OpeningDate = new DateTime(2020, 1, 15), Balance = 1500, Overdraft = 500 };
			Account a2 = new Account { AccountNumber = "FR310186823810", OpeningDate = new DateTime(2019, 5, 20), Balance = 2000, Overdraft = 1000 };
			Account a3 = new Account { AccountNumber = "FR331826409376", OpeningDate = new DateTime(2021, 7, 10), Balance = 800, Overdraft = 500 };
			Account a4 = new Account { AccountNumber = "FR371412253044", OpeningDate = new DateTime(2018, 3, 8), Balance = 3000, Overdraft = 2000 };
			Account a5 = new Account { AccountNumber = "FR405166505325", OpeningDate = new DateTime(2022, 9, 25), Balance = 1200, Overdraft = 1000 };
			Account a6 = new Account { AccountNumber = "FR592259348790", OpeningDate = new DateTime(2017, 11, 30), Balance = 500, Overdraft = 300 };
			Account a7 = new Account { AccountNumber = "FR643394271755", OpeningDate = new DateTime(2016, 4, 12), Balance = 2500, Overdraft = 1500 };
			Account a8 = new Account { AccountNumber = "FR660696569483", OpeningDate = new DateTime(2019, 8, 18), Balance = 1800, Overdraft = 800 };
			Account a9 = new Account { AccountNumber = "FR859315945305", OpeningDate = new DateTime(2020, 2, 5), Balance = 900, Overdraft = 600 };
			Account a10 = new Account { AccountNumber = "FR960338827440", OpeningDate = new DateTime(2023, 6, 14), Balance = 2100, Overdraft = 1200 };

			modelBuilder.Entity<Account>().HasData(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10);

			modelBuilder.Entity("AccountOwners")
				.HasData(
					new { AccountsAccountNumber = a1.AccountNumber, OwnersId = 1 },
					new { AccountsAccountNumber = a2.AccountNumber, OwnersId = 2 },
					new { AccountsAccountNumber = a3.AccountNumber, OwnersId = 3 },
					new { AccountsAccountNumber = a3.AccountNumber, OwnersId = 9 },
					new { AccountsAccountNumber = a4.AccountNumber, OwnersId = 4 },
					new { AccountsAccountNumber = a5.AccountNumber, OwnersId = 5 },
					new { AccountsAccountNumber = a6.AccountNumber, OwnersId = 5 },
					new { AccountsAccountNumber = a7.AccountNumber, OwnersId = 7 },
					new { AccountsAccountNumber = a8.AccountNumber, OwnersId = 8 },
					new { AccountsAccountNumber = a9.AccountNumber, OwnersId = 9 },
					new { AccountsAccountNumber = a10.AccountNumber, OwnersId = 10 }
				);

			modelBuilder.Entity<BankCard>().HasData(
				new BankCard { CardNumber = "4974018502231235", AccountNumber = "FR294067299996" },
				new BankCard { CardNumber = "4974018502238270", AccountNumber = "FR310186823810" },
				new BankCard { CardNumber = "4974018502239788", AccountNumber = "FR331826409376" },
				new BankCard { CardNumber = "4974018502239585", AccountNumber = "FR371412253044" },
				new BankCard { CardNumber = "4974018502237529", AccountNumber = "FR405166505325" },
				new BankCard { CardNumber = "4974018502230410", AccountNumber = "FR592259348790" },
				new BankCard { CardNumber = "4974018502231297", AccountNumber = "FR643394271755" },
				new BankCard { CardNumber = "4974018502230778", AccountNumber = "FR660696569483" },
				new BankCard { CardNumber = "4974018502233220", AccountNumber = "FR294067299996" },
				new BankCard { CardNumber = "4974018502230660", AccountNumber = "FR960338827440" }
			);

			//modelBuilder.Entity<Transaction>()
			//	.HasData(
			//		new Transaction { Id = 1, CardNumber = "4974018502231235", Amount = 150.75, TransactionType = EnumTransactionType.CashDeposit, TransactionDate = new DateTime(2023, 5, 10), Currency = EnumCurrency.EUR },
			//		new Transaction { Id = 2, CardNumber = "4974018502238270", Amount = 75.50, TransactionType = EnumTransactionType.CashWithdrawal, TransactionDate = new DateTime(2023, 6, 15), Currency = EnumCurrency.USD },
			//		new Transaction { Id = 3, CardNumber = "4974018502233920", Amount = 220.00, TransactionType = EnumTransactionType.CardPayment, TransactionDate = new DateTime(2023, 7, 20), Currency = EnumCurrency.EUR },
			//		new Transaction { Id = 4, CardNumber = "4974018502234671", Amount = 50.00, TransactionType = EnumTransactionType.CashDeposit, TransactionDate = new DateTime(2023, 8, 5), Currency = EnumCurrency.GBP },
			//		new Transaction { Id = 5, CardNumber = "4974018502235218", Amount = 300.00, TransactionType = EnumTransactionType.CashWithdrawal, TransactionDate = new DateTime(2023, 9, 1), Currency = EnumCurrency.EUR },
			//		new Transaction { Id = 6, CardNumber = "4974018502236345", Amount = 125.25, TransactionType = EnumTransactionType.CardPayment, TransactionDate = new DateTime(2023, 10, 10), Currency = EnumCurrency.USD },
			//		new Transaction { Id = 7, CardNumber = "4974018502237422", Amount = 400.00, TransactionType = EnumTransactionType.CashDeposit, TransactionDate = new DateTime(2023, 11, 12), Currency = EnumCurrency.EUR },
			//		new Transaction { Id = 8, CardNumber = "4974018502238539", Amount = 20.00, TransactionType = EnumTransactionType.CashWithdrawal, TransactionDate = new DateTime(2023, 12, 20), Currency = EnumCurrency.GBP },
			//		new Transaction { Id = 9, CardNumber = "4974018502239656", Amount = 180.75, TransactionType = EnumTransactionType.CardPayment, TransactionDate = new DateTime(2024, 1, 5), Currency = EnumCurrency.EUR },
			//		new Transaction { Id = 10, CardNumber = "4974018502230782", Amount = 99.99, TransactionType = EnumTransactionType.CashDeposit, TransactionDate = new DateTime(2024, 2, 15), Currency = EnumCurrency.USD }
			//	);

			//modelBuilder.Entity<Anomaly>()
			//	.HasData(
			//		new Anomaly { Id = 11, CardNumber = "4974018502231299", Amount = 500.00, TransactionType = EnumTransactionType.CashWithdrawal, TransactionDate = new DateTime(2023, 5, 10), Currency = EnumCurrency.EUR },
			//		new Anomaly { Id = 12, CardNumber = "4974018502235679", Amount = 200.75, TransactionType = EnumTransactionType.CashDeposit, TransactionDate = new DateTime(2023, 6, 15), Currency = EnumCurrency.USD }
			//	);

            modelBuilder.Entity<LoginUser>()
                .HasData(
                    new LoginUser { Id = 1, Name = "BETY", Email = "bety@gmail.com", PasswordHash = "$10$N1Cdh3fzVyCK2uocu.eZL.ORhH3nDZ3/KIsjtUgGOH285.YrCyI5u" },
                    new LoginUser { Id = 2, Name = "AXA", Email = "info@axa.fr", PasswordHash = "$10$jm2roECdgx9lLpehMRm42ulOy47spo7Z9FGGfNuqCqe92ZvdRGxxu" }
                );

        }
	}
}
