using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flow.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ReplaceUniqueConstraintToUniqueIndexForBanks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Banks_Name",
                table: "Banks");

            migrationBuilder.CreateIndex(
                name: "IX_Banks_Name",
                table: "Banks",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Banks_Name",
                table: "Banks");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Banks_Name",
                table: "Banks",
                column: "Name");
        }
    }
}
