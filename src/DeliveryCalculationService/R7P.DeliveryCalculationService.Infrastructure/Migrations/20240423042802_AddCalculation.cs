using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace R7P.DeliveryCalculationService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCalculation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Segments_DepartureAddressId",
                table: "Segments");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Segments_DepartureAddressId_DestinationAddressId",
                table: "Segments",
                columns: new[] { "DepartureAddressId", "DestinationAddressId" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_AddressSpecs_AddressInfo",
                table: "AddressSpecs",
                column: "AddressInfo");

            migrationBuilder.CreateTable(
                name: "Calculations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DeliveryTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    Cost = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calculations", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calculations");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Segments_DepartureAddressId_DestinationAddressId",
                table: "Segments");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_AddressSpecs_AddressInfo",
                table: "AddressSpecs");

            migrationBuilder.CreateIndex(
                name: "IX_Segments_DepartureAddressId",
                table: "Segments",
                column: "DepartureAddressId");
        }
    }
}
