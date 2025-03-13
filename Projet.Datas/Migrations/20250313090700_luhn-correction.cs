using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Projet.Datas.Migrations
{
    /// <inheritdoc />
    public partial class luhncorrection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Anomalies",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Anomalies",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "BankCards",
                keyColumns: new[] { "AccountNumber", "CardNumber" },
                keyValues: new object[] { "FR592259348790", "4974018502230410" });

            migrationBuilder.DeleteData(
                table: "BankCards",
                keyColumns: new[] { "AccountNumber", "CardNumber" },
                keyValues: new object[] { "FR960338827440", "4974018502230660" });

            migrationBuilder.DeleteData(
                table: "BankCards",
                keyColumns: new[] { "AccountNumber", "CardNumber" },
                keyValues: new object[] { "FR660696569483", "4974018502230778" });

            migrationBuilder.DeleteData(
                table: "BankCards",
                keyColumns: new[] { "AccountNumber", "CardNumber" },
                keyValues: new object[] { "FR294067299996", "4974018502231235" });

            migrationBuilder.DeleteData(
                table: "BankCards",
                keyColumns: new[] { "AccountNumber", "CardNumber" },
                keyValues: new object[] { "FR643394271755", "4974018502231297" });

            migrationBuilder.DeleteData(
                table: "BankCards",
                keyColumns: new[] { "AccountNumber", "CardNumber" },
                keyValues: new object[] { "FR294067299996", "4974018502233220" });

            migrationBuilder.DeleteData(
                table: "BankCards",
                keyColumns: new[] { "AccountNumber", "CardNumber" },
                keyValues: new object[] { "FR405166505325", "4974018502237529" });

            migrationBuilder.DeleteData(
                table: "BankCards",
                keyColumns: new[] { "AccountNumber", "CardNumber" },
                keyValues: new object[] { "FR310186823810", "4974018502238270" });

            migrationBuilder.DeleteData(
                table: "BankCards",
                keyColumns: new[] { "AccountNumber", "CardNumber" },
                keyValues: new object[] { "FR371412253044", "4974018502239585" });

            migrationBuilder.DeleteData(
                table: "BankCards",
                keyColumns: new[] { "AccountNumber", "CardNumber" },
                keyValues: new object[] { "FR331826409376", "4974018502239788" });

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.InsertData(
                table: "BankCards",
                columns: new[] { "AccountNumber", "CardNumber" },
                values: new object[,]
                {
                    { "FR660696569483", "4974018502231281" },
                    { "FR310186823810", "4974018502231752" },
                    { "FR331826409376", "4974018502232347" },
                    { "FR643394271755", "4974018502232925" },
                    { "FR960338827440", "4974018502234939" },
                    { "FR592259348790", "4974018502237197" },
                    { "FR294067299996", "4974018502238054" },
                    { "FR405166505325", "4974018502238880" },
                    { "FR294067299996", "4974018502239284" },
                    { "FR371412253044", "4974018502239847" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BankCards",
                keyColumns: new[] { "AccountNumber", "CardNumber" },
                keyValues: new object[] { "FR660696569483", "4974018502231281" });

            migrationBuilder.DeleteData(
                table: "BankCards",
                keyColumns: new[] { "AccountNumber", "CardNumber" },
                keyValues: new object[] { "FR310186823810", "4974018502231752" });

            migrationBuilder.DeleteData(
                table: "BankCards",
                keyColumns: new[] { "AccountNumber", "CardNumber" },
                keyValues: new object[] { "FR331826409376", "4974018502232347" });

            migrationBuilder.DeleteData(
                table: "BankCards",
                keyColumns: new[] { "AccountNumber", "CardNumber" },
                keyValues: new object[] { "FR643394271755", "4974018502232925" });

            migrationBuilder.DeleteData(
                table: "BankCards",
                keyColumns: new[] { "AccountNumber", "CardNumber" },
                keyValues: new object[] { "FR960338827440", "4974018502234939" });

            migrationBuilder.DeleteData(
                table: "BankCards",
                keyColumns: new[] { "AccountNumber", "CardNumber" },
                keyValues: new object[] { "FR592259348790", "4974018502237197" });

            migrationBuilder.DeleteData(
                table: "BankCards",
                keyColumns: new[] { "AccountNumber", "CardNumber" },
                keyValues: new object[] { "FR294067299996", "4974018502238054" });

            migrationBuilder.DeleteData(
                table: "BankCards",
                keyColumns: new[] { "AccountNumber", "CardNumber" },
                keyValues: new object[] { "FR405166505325", "4974018502238880" });

            migrationBuilder.DeleteData(
                table: "BankCards",
                keyColumns: new[] { "AccountNumber", "CardNumber" },
                keyValues: new object[] { "FR294067299996", "4974018502239284" });

            migrationBuilder.DeleteData(
                table: "BankCards",
                keyColumns: new[] { "AccountNumber", "CardNumber" },
                keyValues: new object[] { "FR371412253044", "4974018502239847" });

            migrationBuilder.InsertData(
                table: "Anomalies",
                columns: new[] { "Id", "AccountNumber", "Amount", "CardNumber", "Currency", "TransactionDate", "TransactionType" },
                values: new object[,]
                {
                    { 11, null, 500.0, "4974018502231299", "EUR", new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "CashWithdrawal" },
                    { 12, null, 200.75, "4974018502235679", "USD", new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "CashDeposit" }
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
        }
    }
}
