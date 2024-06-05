using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace R7P.DeliveryCalculationService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEstimateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "EstimateTimeToStart",
                schema: "dbo",
                table: "Calculations",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstimateTimeToStart",
                schema: "dbo",
                table: "Calculations");
        }
    }
}
