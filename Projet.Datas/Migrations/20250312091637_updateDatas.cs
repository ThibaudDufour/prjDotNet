using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projet.Datas.Migrations
{
    /// <inheritdoc />
    public partial class updateDatas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Anomalies",
                keyColumn: "Id",
                keyValue: 11,
                column: "CardNumber",
                value: "4974018502231299");

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CardNumber",
                value: "4974018502233220");

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CardNumber",
                value: "4974018502233220");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Anomalies",
                keyColumn: "Id",
                keyValue: 11,
                column: "CardNumber",
                value: "4974018502231235");

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CardNumber",
                value: "4974018502233920");

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 7,
                column: "CardNumber",
                value: "4974018502237422");
        }
    }
}
