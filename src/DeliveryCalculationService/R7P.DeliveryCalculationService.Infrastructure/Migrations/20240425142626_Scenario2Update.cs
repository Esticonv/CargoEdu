using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace R7P.DeliveryCalculationService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Scenario2Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DepartureAddressId",
                table: "Calculations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "DestinationAddressId",
                table: "Calculations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "MachineId",
                table: "Calculations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Calculations_DepartureAddressId",
                table: "Calculations",
                column: "DepartureAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Calculations_DestinationAddressId",
                table: "Calculations",
                column: "DestinationAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Calculations_AddressSpecs_DepartureAddressId",
                table: "Calculations",
                column: "DepartureAddressId",
                principalTable: "AddressSpecs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Calculations_AddressSpecs_DestinationAddressId",
                table: "Calculations",
                column: "DestinationAddressId",
                principalTable: "AddressSpecs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calculations_AddressSpecs_DepartureAddressId",
                table: "Calculations");

            migrationBuilder.DropForeignKey(
                name: "FK_Calculations_AddressSpecs_DestinationAddressId",
                table: "Calculations");

            migrationBuilder.DropIndex(
                name: "IX_Calculations_DepartureAddressId",
                table: "Calculations");

            migrationBuilder.DropIndex(
                name: "IX_Calculations_DestinationAddressId",
                table: "Calculations");

            migrationBuilder.DropColumn(
                name: "DepartureAddressId",
                table: "Calculations");

            migrationBuilder.DropColumn(
                name: "DestinationAddressId",
                table: "Calculations");

            migrationBuilder.DropColumn(
                name: "MachineId",
                table: "Calculations");
        }
    }
}
