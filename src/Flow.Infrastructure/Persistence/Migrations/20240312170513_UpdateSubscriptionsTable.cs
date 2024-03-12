using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flow.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSubscriptionsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Subscriptions");

            migrationBuilder.RenameColumn(
                name: "Service",
                table: "Subscriptions",
                newName: "Name");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeactivatedAt",
                table: "Subscriptions",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeactivated",
                table: "Subscriptions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PaymentFrequencyMonths",
                table: "Subscriptions",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeactivatedAt",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "IsDeactivated",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "PaymentFrequencyMonths",
                table: "Subscriptions");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Subscriptions",
                newName: "Service");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Subscriptions",
                type: "boolean",
                nullable: true,
                defaultValue: true);
        }
    }
}
