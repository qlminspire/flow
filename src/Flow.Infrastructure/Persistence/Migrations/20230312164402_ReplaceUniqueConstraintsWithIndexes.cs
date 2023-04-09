using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flow.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ReplaceUniqueConstraintsWithIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Users_Email",
                table: "Users");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_UserCategories_UserId_Name",
                table: "UserCategories");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserCategories_UserId_Name",
                table: "UserCategories",
                columns: new[] { "UserId", "Name" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_UserCategories_UserId_Name",
                table: "UserCategories");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Users_Email",
                table: "Users",
                column: "Email");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_UserCategories_UserId_Name",
                table: "UserCategories",
                columns: new[] { "UserId", "Name" });
        }
    }
}
