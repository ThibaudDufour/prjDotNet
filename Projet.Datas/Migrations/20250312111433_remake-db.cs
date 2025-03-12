using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Projet.Datas.Migrations
{
    /// <inheritdoc />
    public partial class remakedb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "TransactionSequence");

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OpeningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    Overdraft = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountNumber);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoginUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Anomalies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [TransactionSequence]"),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    TransactionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anomalies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Anomalies_Accounts_AccountNumber",
                        column: x => x.AccountNumber,
                        principalTable: "Accounts",
                        principalColumn: "AccountNumber");
                });

            migrationBuilder.CreateTable(
                name: "BankCards",
                columns: table => new
                {
                    CardNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankCards", x => new { x.CardNumber, x.AccountNumber });
                    table.ForeignKey(
                        name: "FK_BankCards_Accounts_AccountNumber",
                        column: x => x.AccountNumber,
                        principalTable: "Accounts",
                        principalColumn: "AccountNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [TransactionSequence]"),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    TransactionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_AccountNumber",
                        column: x => x.AccountNumber,
                        principalTable: "Accounts",
                        principalColumn: "AccountNumber");
                });

            migrationBuilder.CreateTable(
                name: "AccountOwners",
                columns: table => new
                {
                    OwnersId = table.Column<int>(type: "int", nullable: false),
                    AccountsAccountNumber = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountOwners", x => new { x.OwnersId, x.AccountsAccountNumber });
                    table.ForeignKey(
                        name: "FK_AccountOwners_Accounts_AccountsAccountNumber",
                        column: x => x.AccountsAccountNumber,
                        principalTable: "Accounts",
                        principalColumn: "AccountNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountOwners_Customers_OwnersId",
                        column: x => x.OwnersId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessCustomers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Siret = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    LegalStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SiegeLabel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SiegeComplement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SiegePostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SiegeCity = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessCustomers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessCustomers_Customers_Id",
                        column: x => x.Id,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrivateCustomers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    DateBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivateCustomers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrivateCustomers_Customers_Id",
                        column: x => x.Id,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountNumber", "Balance", "OpeningDate", "Overdraft" },
                values: new object[,]
                {
                    { "FR294067299996", 1500.0, new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 500 },
                    { "FR310186823810", 2000.0, new DateTime(2019, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000 },
                    { "FR331826409376", 800.0, new DateTime(2021, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 500 },
                    { "FR371412253044", 3000.0, new DateTime(2018, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2000 },
                    { "FR405166505325", 1200.0, new DateTime(2022, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000 },
                    { "FR592259348790", 500.0, new DateTime(2017, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 300 },
                    { "FR643394271755", 2500.0, new DateTime(2016, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1500 },
                    { "FR660696569483", 1800.0, new DateTime(2019, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 800 },
                    { "FR859315945305", 900.0, new DateTime(2020, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 600 },
                    { "FR960338827440", 2100.0, new DateTime(2023, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1200 }
                });

            migrationBuilder.InsertData(
                table: "Anomalies",
                columns: new[] { "Id", "AccountNumber", "Amount", "CardNumber", "Currency", "TransactionDate", "TransactionType" },
                values: new object[,]
                {
                    { 11, null, 500.0, "4974018502231299", "EUR", new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "CashWithdrawal" },
                    { 12, null, 200.75, "4974018502235679", "USD", new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "CashDeposit" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "AdditionalInfo", "City", "Email", "Label", "Name", "PostalCode" },
                values: new object[,]
                {
                    { 1, null, "CRETEIL", "bety@gmail.com", "12, rue des Oliviers", "BETY", "94000" },
                    { 2, "Digicode 1432", "FONTENAY SOUS BOIS", "info@axa.fr", "125, rue LaFayette", "AXA", "94120" },
                    { 3, "Etage 2", "VINCENNES", "bodin@gmail.com", "10, rue des Olivies", "BODIN", "94300" },
                    { 4, null, "ROISSY EN FRANCE", "info@paul.fr", "36, quai des Orfèvres", "PAUL", "93500" },
                    { 5, null, "FONTENAY SOUS BOIS", "berris@gmail.com", "15, rue de la République", "BERRIS", "94120" },
                    { 6, "Bat. C", "PARIS", "contact@primark.fr", "32, rue E. Renan", "PRIMARK", "75002" },
                    { 7, null, "LA DEFENSE", "abenir@gmail.com", "25, rue de la Paix", "ABENIR", "92100" },
                    { 8, null, "LA DEFENSE", "info@zara.fr", "23, av P. Valery", "ZARA", "92100" },
                    { 9, null, "ROISSY EN FRANCE", "bensaid@gmail.com", "3, avenue des Parcs", "BENSAID", "93500" },
                    { 10, "Fond de Cour", "PARIS", "contact@leonidas.fr", "15, Place de la Bastille", "LEONIDAS", "75003" },
                    { 11, null, "BAGNOLET", "ababou@gmail.com", "3, rue Lecourbe", "ABABOU", "93200" }
                });

            migrationBuilder.InsertData(
                table: "LoginUsers",
                columns: new[] { "Id", "Email", "Name", "PasswordHash" },
                values: new object[,]
                {
                    { 1, "bety@gmail.com", "BETY", "$10$N1Cdh3fzVyCK2uocu.eZL.ORhH3nDZ3/KIsjtUgGOH285.YrCyI5u" },
                    { 2, "info@axa.fr", "AXA", "$10$jm2roECdgx9lLpehMRm42ulOy47spo7Z9FGGfNuqCqe92ZvdRGxxu" }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "AccountNumber", "Amount", "CardNumber", "Currency", "TransactionDate", "TransactionType" },
                values: new object[,]
                {
                    { 1, null, 150.75, "4974018502231235", "EUR", new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "CashDeposit" },
                    { 2, null, 75.5, "4974018502238270", "USD", new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "CashWithdrawal" },
                    { 3, null, 220.0, "4974018502233920", "EUR", new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "CardPayment" },
                    { 4, null, 50.0, "4974018502234671", "GBP", new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "CashDeposit" },
                    { 5, null, 300.0, "4974018502235218", "EUR", new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CashWithdrawal" },
                    { 6, null, 125.25, "4974018502236345", "USD", new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "CardPayment" },
                    { 7, null, 400.0, "4974018502237422", "EUR", new DateTime(2023, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CashDeposit" },
                    { 8, null, 20.0, "4974018502238539", "GBP", new DateTime(2023, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "CashWithdrawal" },
                    { 9, null, 180.75, "4974018502239656", "EUR", new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "CardPayment" },
                    { 10, null, 99.989999999999995, "4974018502230782", "USD", new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "CashDeposit" }
                });

            migrationBuilder.InsertData(
                table: "AccountOwners",
                columns: new[] { "AccountsAccountNumber", "OwnersId" },
                values: new object[,]
                {
                    { "FR294067299996", 1 },
                    { "FR310186823810", 2 },
                    { "FR331826409376", 3 },
                    { "FR371412253044", 4 },
                    { "FR405166505325", 5 },
                    { "FR592259348790", 5 },
                    { "FR643394271755", 7 },
                    { "FR660696569483", 8 },
                    { "FR331826409376", 9 },
                    { "FR859315945305", 9 },
                    { "FR960338827440", 10 }
                });

            migrationBuilder.InsertData(
                table: "BankCards",
                columns: new[] { "AccountNumber", "CardNumber" },
                values: new object[,]
                {
                    { "FR592259348790", "4974018502230410" },
                    { "FR960338827440", "4974018502230660" },
                    { "FR660696569483", "4974018502230778" },
                    { "FR294067299996", "4974018502231235" },
                    { "FR643394271755", "4974018502231297" },
                    { "FR294067299996", "4974018502233220" },
                    { "FR405166505325", "4974018502237529" },
                    { "FR310186823810", "4974018502238270" },
                    { "FR371412253044", "4974018502239585" },
                    { "FR331826409376", "4974018502239788" }
                });

            migrationBuilder.InsertData(
                table: "BusinessCustomers",
                columns: new[] { "Id", "LegalStatus", "SiegeCity", "SiegeComplement", "SiegeLabel", "SiegePostalCode", "Siret" },
                values: new object[,]
                {
                    { 2, "SARL", "FONTENAY SOUS BOIS", "Digicode 1432", "125, rue LaFayette", "94120", "12548795641122" },
                    { 4, "EURL", "LA DEFENSE", null, "10, esplanade de la Défense", "92060", "87459564455444" },
                    { 6, "SARL", "PARIS", "Bat. C", "32, rue E. Renan", "75002", "08755897458455" },
                    { 8, "SA", "LA DEFENSE", "Tour Franklin", "24, esplanade de la Défense", "92060", "65895874587854" },
                    { 10, "SAS", "PARIS", null, "10, rue de la Paix", "75008", "91235987456832" }
                });

            migrationBuilder.InsertData(
                table: "PrivateCustomers",
                columns: new[] { "Id", "DateBirth", "FirstName", "Sex" },
                values: new object[,]
                {
                    { 1, new DateTime(1985, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel", "Male" },
                    { 3, new DateTime(1965, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Justin", "Male" },
                    { 5, new DateTime(1977, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Karine", "Female" },
                    { 7, new DateTime(1977, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alexandra", "Female" },
                    { 9, new DateTime(1976, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Georgia", "Female" },
                    { 11, new DateTime(1970, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Teddy", "Male" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountOwners_AccountsAccountNumber",
                table: "AccountOwners",
                column: "AccountsAccountNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Anomalies_AccountNumber",
                table: "Anomalies",
                column: "AccountNumber");

            migrationBuilder.CreateIndex(
                name: "IX_BankCards_AccountNumber",
                table: "BankCards",
                column: "AccountNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountNumber",
                table: "Transactions",
                column: "AccountNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountOwners");

            migrationBuilder.DropTable(
                name: "Anomalies");

            migrationBuilder.DropTable(
                name: "BankCards");

            migrationBuilder.DropTable(
                name: "BusinessCustomers");

            migrationBuilder.DropTable(
                name: "LoginUsers");

            migrationBuilder.DropTable(
                name: "PrivateCustomers");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropSequence(
                name: "TransactionSequence");
        }
    }
}
