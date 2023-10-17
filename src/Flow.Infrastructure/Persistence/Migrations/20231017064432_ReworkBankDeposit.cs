using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flow.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ReworkBankDeposit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankDeposits_BankAccounts_RefundAccountId",
                table: "BankDeposits");

            migrationBuilder.RenameColumn(
                name: "PeriodInMonthes",
                table: "BankDeposits",
                newName: "PeriodInMonths");

            migrationBuilder.AlterColumn<Guid>(
                name: "RefundAccountId",
                table: "BankDeposits",
                type: "uuid",
                nullable: false,
                defaultValue: Guid.Empty,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BankDeposits_BankAccounts_RefundAccountId",
                table: "BankDeposits",
                column: "RefundAccountId",
                principalTable: "BankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankDeposits_BankAccounts_RefundAccountId",
                table: "BankDeposits");

            migrationBuilder.RenameColumn(
                name: "PeriodInMonths",
                table: "BankDeposits",
                newName: "PeriodInMonthes");

            migrationBuilder.AlterColumn<Guid>(
                name: "RefundAccountId",
                table: "BankDeposits",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_BankDeposits_BankAccounts_RefundAccountId",
                table: "BankDeposits",
                column: "RefundAccountId",
                principalTable: "BankAccounts",
                principalColumn: "Id");
        }
    }
}
