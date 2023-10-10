using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flow.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ExtendSubscriptionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Subscriptions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "PaymentDate",
                table: "Subscriptions",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentPeriod",
                table: "Subscriptions",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "PaymentDate",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "PaymentPeriod",
                table: "Subscriptions");
        }
    }
}
