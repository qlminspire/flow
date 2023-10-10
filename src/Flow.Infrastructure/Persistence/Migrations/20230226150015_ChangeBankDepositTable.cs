using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flow.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeBankDepositTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankDeposits_Accounts_Id",
                table: "BankDeposits");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "BankDeposits",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "BankDeposits",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreateDate",
                table: "BankDeposits",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "CurrencyId",
                table: "BankDeposits",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdateDate",
                table: "BankDeposits",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "BankDeposits",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_BankDeposits_CategoryId",
                table: "BankDeposits",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BankDeposits_CurrencyId",
                table: "BankDeposits",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_BankDeposits_UserId",
                table: "BankDeposits",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BankDeposits_Currencies_CurrencyId",
                table: "BankDeposits",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BankDeposits_UserCategories_CategoryId",
                table: "BankDeposits",
                column: "CategoryId",
                principalTable: "UserCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BankDeposits_Users_UserId",
                table: "BankDeposits",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankDeposits_Currencies_CurrencyId",
                table: "BankDeposits");

            migrationBuilder.DropForeignKey(
                name: "FK_BankDeposits_UserCategories_CategoryId",
                table: "BankDeposits");

            migrationBuilder.DropForeignKey(
                name: "FK_BankDeposits_Users_UserId",
                table: "BankDeposits");

            migrationBuilder.DropIndex(
                name: "IX_BankDeposits_CategoryId",
                table: "BankDeposits");

            migrationBuilder.DropIndex(
                name: "IX_BankDeposits_CurrencyId",
                table: "BankDeposits");

            migrationBuilder.DropIndex(
                name: "IX_BankDeposits_UserId",
                table: "BankDeposits");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "BankDeposits");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "BankDeposits");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "BankDeposits");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "BankDeposits");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "BankDeposits");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BankDeposits");

            migrationBuilder.AddForeignKey(
                name: "FK_BankDeposits_Accounts_Id",
                table: "BankDeposits",
                column: "Id",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
