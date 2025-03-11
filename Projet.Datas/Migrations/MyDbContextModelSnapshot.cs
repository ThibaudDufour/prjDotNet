﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projet.Datas;

#nullable disable

namespace Projet.Datas.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.HasSequence("TransactionSequence");

            modelBuilder.Entity("AccountOwners", b =>
                {
                    b.Property<int>("OwnersId")
                        .HasColumnType("int");

                    b.Property<string>("AccountsAccountNumber")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("OwnersId", "AccountsAccountNumber");

                    b.HasIndex("AccountsAccountNumber");

                    b.ToTable("AccountOwners", (string)null);

                    b.HasData(
                        new
                        {
                            OwnersId = 1,
                            AccountsAccountNumber = "FR294067299996"
                        },
                        new
                        {
                            OwnersId = 2,
                            AccountsAccountNumber = "FR310186823810"
                        },
                        new
                        {
                            OwnersId = 3,
                            AccountsAccountNumber = "FR331826409376"
                        },
                        new
                        {
                            OwnersId = 9,
                            AccountsAccountNumber = "FR331826409376"
                        },
                        new
                        {
                            OwnersId = 4,
                            AccountsAccountNumber = "FR371412253044"
                        },
                        new
                        {
                            OwnersId = 5,
                            AccountsAccountNumber = "FR405166505325"
                        },
                        new
                        {
                            OwnersId = 5,
                            AccountsAccountNumber = "FR592259348790"
                        },
                        new
                        {
                            OwnersId = 7,
                            AccountsAccountNumber = "FR643394271755"
                        },
                        new
                        {
                            OwnersId = 8,
                            AccountsAccountNumber = "FR660696569483"
                        },
                        new
                        {
                            OwnersId = 9,
                            AccountsAccountNumber = "FR859315945305"
                        },
                        new
                        {
                            OwnersId = 10,
                            AccountsAccountNumber = "FR960338827440"
                        });
                });

            modelBuilder.Entity("Projet.Datas.Entities.Account", b =>
                {
                    b.Property<string>("AccountNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Balance")
                        .HasColumnType("float");

                    b.Property<DateTime>("OpeningDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Overdraft")
                        .HasColumnType("int");

                    b.HasKey("AccountNumber");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            AccountNumber = "FR294067299996",
                            Balance = 1500.0,
                            OpeningDate = new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Overdraft = 500
                        },
                        new
                        {
                            AccountNumber = "FR310186823810",
                            Balance = 2000.0,
                            OpeningDate = new DateTime(2019, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Overdraft = 1000
                        },
                        new
                        {
                            AccountNumber = "FR331826409376",
                            Balance = 800.0,
                            OpeningDate = new DateTime(2021, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Overdraft = 500
                        },
                        new
                        {
                            AccountNumber = "FR371412253044",
                            Balance = 3000.0,
                            OpeningDate = new DateTime(2018, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Overdraft = 2000
                        },
                        new
                        {
                            AccountNumber = "FR405166505325",
                            Balance = 1200.0,
                            OpeningDate = new DateTime(2022, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Overdraft = 1000
                        },
                        new
                        {
                            AccountNumber = "FR592259348790",
                            Balance = 500.0,
                            OpeningDate = new DateTime(2017, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Overdraft = 300
                        },
                        new
                        {
                            AccountNumber = "FR643394271755",
                            Balance = 2500.0,
                            OpeningDate = new DateTime(2016, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Overdraft = 1500
                        },
                        new
                        {
                            AccountNumber = "FR660696569483",
                            Balance = 1800.0,
                            OpeningDate = new DateTime(2019, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Overdraft = 800
                        },
                        new
                        {
                            AccountNumber = "FR859315945305",
                            Balance = 900.0,
                            OpeningDate = new DateTime(2020, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Overdraft = 600
                        },
                        new
                        {
                            AccountNumber = "FR960338827440",
                            Balance = 2100.0,
                            OpeningDate = new DateTime(2023, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Overdraft = 1200
                        });
                });

            modelBuilder.Entity("Projet.Datas.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdditionalInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Projet.Datas.Entities.LoginUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LoginUsers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "bety@gmail.com",
                            Name = "BETY",
                            PasswordHash = "$10$N1Cdh3fzVyCK2uocu.eZL.ORhH3nDZ3/KIsjtUgGOH285.YrCyI5u"
                        },
                        new
                        {
                            Id = 2,
                            Email = "info@axa.fr",
                            Name = "AXA",
                            PasswordHash = "$10$jm2roECdgx9lLpehMRm42ulOy47spo7Z9FGGfNuqCqe92ZvdRGxxu"
                        });
                });

            modelBuilder.Entity("Projet.Datas.Entities.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("NEXT VALUE FOR [TransactionSequence]");

                    SqlServerPropertyBuilderExtensions.UseSequence(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<string>("BankAccountAccountNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BankAccountNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TransactionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BankAccountAccountNumber");

                    b.ToTable("Transactions", (string)null);

                    b.UseTpcMappingStrategy();

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 150.75,
                            BankAccountNumber = "FR294067299996",
                            CardNumber = "4974018502231456",
                            Currency = "EUR",
                            TransactionDate = new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TransactionType = "CashDeposit"
                        },
                        new
                        {
                            Id = 2,
                            Amount = 75.5,
                            BankAccountNumber = "FR310186823810",
                            CardNumber = "4974018502232783",
                            Currency = "USD",
                            TransactionDate = new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TransactionType = "CashWithdrawal"
                        },
                        new
                        {
                            Id = 3,
                            Amount = 220.0,
                            BankAccountNumber = "FR331826409376",
                            CardNumber = "4974018502233920",
                            Currency = "EUR",
                            TransactionDate = new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TransactionType = "CardPayment"
                        },
                        new
                        {
                            Id = 4,
                            Amount = 50.0,
                            BankAccountNumber = "FR371412253044",
                            CardNumber = "4974018502234671",
                            Currency = "GBP",
                            TransactionDate = new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TransactionType = "CashDeposit"
                        },
                        new
                        {
                            Id = 5,
                            Amount = 300.0,
                            BankAccountNumber = "FR405166505325",
                            CardNumber = "4974018502235218",
                            Currency = "EUR",
                            TransactionDate = new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TransactionType = "CashWithdrawal"
                        },
                        new
                        {
                            Id = 6,
                            Amount = 125.25,
                            BankAccountNumber = "FR592259348790",
                            CardNumber = "4974018502236345",
                            Currency = "USD",
                            TransactionDate = new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TransactionType = "CardPayment"
                        },
                        new
                        {
                            Id = 7,
                            Amount = 400.0,
                            BankAccountNumber = "FR643394271755",
                            CardNumber = "4974018502237422",
                            Currency = "EUR",
                            TransactionDate = new DateTime(2023, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TransactionType = "CashDeposit"
                        },
                        new
                        {
                            Id = 8,
                            Amount = 20.0,
                            BankAccountNumber = "FR660696569483",
                            CardNumber = "4974018502238539",
                            Currency = "GBP",
                            TransactionDate = new DateTime(2023, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TransactionType = "CashWithdrawal"
                        },
                        new
                        {
                            Id = 9,
                            Amount = 180.75,
                            BankAccountNumber = "FR859315945305",
                            CardNumber = "4974018502239656",
                            Currency = "EUR",
                            TransactionDate = new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TransactionType = "CardPayment"
                        },
                        new
                        {
                            Id = 10,
                            Amount = 99.989999999999995,
                            BankAccountNumber = "FR960338827440",
                            CardNumber = "4974018502230782",
                            Currency = "USD",
                            TransactionDate = new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TransactionType = "CashDeposit"
                        });
                });

            modelBuilder.Entity("Projet.Datas.Entities.BusinessCustomer", b =>
                {
                    b.HasBaseType("Projet.Datas.Entities.Customer");

                    b.Property<string>("LegalStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SiegeCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SiegeComplement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SiegeLabel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SiegePostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Siret")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.ToTable("BusinessCustomers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 2,
                            AdditionalInfo = "Digicode 1432",
                            City = "FONTENAY SOUS BOIS",
                            Email = "info@axa.fr",
                            Label = "125, rue LaFayette",
                            Name = "AXA",
                            PostalCode = "94120",
                            LegalStatus = "SARL",
                            SiegeCity = "FONTENAY SOUS BOIS",
                            SiegeComplement = "Digicode 1432",
                            SiegeLabel = "125, rue LaFayette",
                            SiegePostalCode = "94120",
                            Siret = "12548795641122"
                        },
                        new
                        {
                            Id = 4,
                            City = "ROISSY EN FRANCE",
                            Email = "info@paul.fr",
                            Label = "36, quai des Orfèvres",
                            Name = "PAUL",
                            PostalCode = "93500",
                            LegalStatus = "EURL",
                            SiegeCity = "LA DEFENSE",
                            SiegeLabel = "10, esplanade de la Défense",
                            SiegePostalCode = "92060",
                            Siret = "87459564455444"
                        },
                        new
                        {
                            Id = 6,
                            AdditionalInfo = "Bat. C",
                            City = "PARIS",
                            Email = "contact@primark.fr",
                            Label = "32, rue E. Renan",
                            Name = "PRIMARK",
                            PostalCode = "75002",
                            LegalStatus = "SARL",
                            SiegeCity = "PARIS",
                            SiegeComplement = "Bat. C",
                            SiegeLabel = "32, rue E. Renan",
                            SiegePostalCode = "75002",
                            Siret = "08755897458455"
                        },
                        new
                        {
                            Id = 8,
                            City = "LA DEFENSE",
                            Email = "info@zara.fr",
                            Label = "23, av P. Valery",
                            Name = "ZARA",
                            PostalCode = "92100",
                            LegalStatus = "SA",
                            SiegeCity = "LA DEFENSE",
                            SiegeComplement = "Tour Franklin",
                            SiegeLabel = "24, esplanade de la Défense",
                            SiegePostalCode = "92060",
                            Siret = "65895874587854"
                        },
                        new
                        {
                            Id = 10,
                            AdditionalInfo = "Fond de Cour",
                            City = "PARIS",
                            Email = "contact@leonidas.fr",
                            Label = "15, Place de la Bastille",
                            Name = "LEONIDAS",
                            PostalCode = "75003",
                            LegalStatus = "SAS",
                            SiegeCity = "PARIS",
                            SiegeLabel = "10, rue de la Paix",
                            SiegePostalCode = "75008",
                            Siret = "91235987456832"
                        });
                });

            modelBuilder.Entity("Projet.Datas.Entities.PrivateCustomer", b =>
                {
                    b.HasBaseType("Projet.Datas.Entities.Customer");

                    b.Property<DateTime>("DateBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("PrivateCustomers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "CRETEIL",
                            Email = "bety@gmail.com",
                            Label = "12, rue des Oliviers",
                            Name = "BETY",
                            PostalCode = "94000",
                            DateBirth = new DateTime(1985, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Daniel",
                            Sex = "Male"
                        },
                        new
                        {
                            Id = 3,
                            AdditionalInfo = "Etage 2",
                            City = "VINCENNES",
                            Email = "bodin@gmail.com",
                            Label = "10, rue des Olivies",
                            Name = "BODIN",
                            PostalCode = "94300",
                            DateBirth = new DateTime(1965, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Justin",
                            Sex = "Male"
                        },
                        new
                        {
                            Id = 5,
                            City = "FONTENAY SOUS BOIS",
                            Email = "berris@gmail.com",
                            Label = "15, rue de la République",
                            Name = "BERRIS",
                            PostalCode = "94120",
                            DateBirth = new DateTime(1977, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Karine",
                            Sex = "Female"
                        },
                        new
                        {
                            Id = 7,
                            City = "LA DEFENSE",
                            Email = "abenir@gmail.com",
                            Label = "25, rue de la Paix",
                            Name = "ABENIR",
                            PostalCode = "92100",
                            DateBirth = new DateTime(1977, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Alexandra",
                            Sex = "Female"
                        },
                        new
                        {
                            Id = 9,
                            City = "ROISSY EN FRANCE",
                            Email = "bensaid@gmail.com",
                            Label = "3, avenue des Parcs",
                            Name = "BENSAID",
                            PostalCode = "93500",
                            DateBirth = new DateTime(1976, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Georgia",
                            Sex = "Female"
                        },
                        new
                        {
                            Id = 11,
                            City = "BAGNOLET",
                            Email = "ababou@gmail.com",
                            Label = "3, rue Lecourbe",
                            Name = "ABABOU",
                            PostalCode = "93200",
                            DateBirth = new DateTime(1970, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Teddy",
                            Sex = "Male"
                        });
                });

            modelBuilder.Entity("Projet.Datas.Entities.Anomaly", b =>
                {
                    b.HasBaseType("Projet.Datas.Entities.Transaction");

                    b.ToTable("Anomalies", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 11,
                            Amount = 500.0,
                            BankAccountNumber = "FR660696569483",
                            CardNumber = "4974018502231235",
                            Currency = "EUR",
                            TransactionDate = new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TransactionType = "CashWithdrawal"
                        },
                        new
                        {
                            Id = 12,
                            Amount = 200.75,
                            BankAccountNumber = "FR405166505325",
                            CardNumber = "4974018502235679",
                            Currency = "USD",
                            TransactionDate = new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TransactionType = "CashDeposit"
                        });
                });

            modelBuilder.Entity("AccountOwners", b =>
                {
                    b.HasOne("Projet.Datas.Entities.Account", null)
                        .WithMany()
                        .HasForeignKey("AccountsAccountNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projet.Datas.Entities.Customer", null)
                        .WithMany()
                        .HasForeignKey("OwnersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Projet.Datas.Entities.Transaction", b =>
                {
                    b.HasOne("Projet.Datas.Entities.Account", "BankAccount")
                        .WithMany("Transactions")
                        .HasForeignKey("BankAccountAccountNumber");

                    b.Navigation("BankAccount");
                });

            modelBuilder.Entity("Projet.Datas.Entities.BusinessCustomer", b =>
                {
                    b.HasOne("Projet.Datas.Entities.Customer", null)
                        .WithOne()
                        .HasForeignKey("Projet.Datas.Entities.BusinessCustomer", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Projet.Datas.Entities.PrivateCustomer", b =>
                {
                    b.HasOne("Projet.Datas.Entities.Customer", null)
                        .WithOne()
                        .HasForeignKey("Projet.Datas.Entities.PrivateCustomer", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Projet.Datas.Entities.Account", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
