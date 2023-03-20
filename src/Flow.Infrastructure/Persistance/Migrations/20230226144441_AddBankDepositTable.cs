using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flow.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddBankDepositTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountOperation_Accounts_AccountId",
                table: "AccountOperation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountOperation",
                table: "AccountOperation");

            migrationBuilder.RenameTable(
                name: "AccountOperation",
                newName: "AccountOperations");

            migrationBuilder.RenameIndex(
                name: "IX_AccountOperation_AccountId",
                table: "AccountOperations",
                newName: "IX_AccountOperations_AccountId");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Date",
                table: "UserIncomes",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "UserCategories",
                type: "character varying(128)",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountOperations",
                table: "AccountOperations",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BankDeposits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Rate = table.Column<double>(type: "double precision", nullable: false),
                    PeriodInMonthes = table.Column<int>(type: "integer", nullable: false),
                    EndDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    RefundAccountId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankDeposits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankDeposits_Accounts_Id",
                        column: x => x.Id,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BankDeposits_BankAccounts_RefundAccountId",
                        column: x => x.RefundAccountId,
                        principalTable: "BankAccounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankDeposits_RefundAccountId",
                table: "BankDeposits",
                column: "RefundAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountOperations_Accounts_AccountId",
                table: "AccountOperations",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountOperations_Accounts_AccountId",
                table: "AccountOperations");

            migrationBuilder.DropTable(
                name: "BankDeposits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountOperations",
                table: "AccountOperations");

            migrationBuilder.RenameTable(
                name: "AccountOperations",
                newName: "AccountOperation");

            migrationBuilder.RenameIndex(
                name: "IX_AccountOperations_AccountId",
                table: "AccountOperation",
                newName: "IX_AccountOperation_AccountId");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Date",
                table: "UserIncomes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "UserCategories",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountOperation",
                table: "AccountOperation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountOperation_Accounts_AccountId",
                table: "AccountOperation",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id");
        }
    }
}
