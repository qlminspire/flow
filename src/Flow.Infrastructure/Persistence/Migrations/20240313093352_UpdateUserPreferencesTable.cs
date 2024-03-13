using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flow.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserPreferencesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BudgetingStartDay",
                table: "UserPreferences");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "UserPreferences",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_UserPreferences_UserId",
                table: "UserPreferences",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPreferences_Users_UserId",
                table: "UserPreferences",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPreferences_Users_UserId",
                table: "UserPreferences");

            migrationBuilder.DropIndex(
                name: "IX_UserPreferences_UserId",
                table: "UserPreferences");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserPreferences");

            migrationBuilder.AddColumn<int>(
                name: "BudgetingStartDay",
                table: "UserPreferences",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
