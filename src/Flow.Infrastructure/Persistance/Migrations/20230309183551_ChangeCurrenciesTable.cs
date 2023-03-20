using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flow.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCurrenciesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Currencies_Code",
                table: "Currencies");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Currencies_Name",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "LastPayment",
                table: "Subscriptions");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Currencies",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_Code",
                table: "Currencies",
                column: "Code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Currencies_Code",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Currencies");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastPayment",
                table: "Subscriptions",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Currencies_Code",
                table: "Currencies",
                column: "Code");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Currencies_Name",
                table: "Currencies",
                column: "Name");
        }
    }
}
