using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace R7P.DeliveryCalculationService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameDbSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calculations_AddressSpecs_DepartureAddressId",
                table: "Calculations");

            migrationBuilder.DropForeignKey(
                name: "FK_Calculations_AddressSpecs_DestinationAddressId",
                table: "Calculations");

            migrationBuilder.DropForeignKey(
                name: "FK_Segments_AddressSpecs_DepartureAddressId",
                table: "Segments");

            migrationBuilder.DropForeignKey(
                name: "FK_Segments_AddressSpecs_DestinationAddressId",
                table: "Segments");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_AddressSpecs_AddressInfo",
                table: "AddressSpecs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AddressSpecs",
                table: "AddressSpecs");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "Segments",
                newName: "Segments",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Calculations",
                newName: "Calculations",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "AddressSpecs",
                newName: "Address",
                newSchema: "dbo");

            migrationBuilder.AddColumn<double>(
                name: "CargoSize",
                schema: "dbo",
                table: "Calculations",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Address_AddressInfo",
                schema: "dbo",
                table: "Address",
                column: "AddressInfo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                schema: "dbo",
                table: "Address",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Calculations_Address_DepartureAddressId",
                schema: "dbo",
                table: "Calculations",
                column: "DepartureAddressId",
                principalSchema: "dbo",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Calculations_Address_DestinationAddressId",
                schema: "dbo",
                table: "Calculations",
                column: "DestinationAddressId",
                principalSchema: "dbo",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Segments_Address_DepartureAddressId",
                schema: "dbo",
                table: "Segments",
                column: "DepartureAddressId",
                principalSchema: "dbo",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Segments_Address_DestinationAddressId",
                schema: "dbo",
                table: "Segments",
                column: "DestinationAddressId",
                principalSchema: "dbo",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calculations_Address_DepartureAddressId",
                schema: "dbo",
                table: "Calculations");

            migrationBuilder.DropForeignKey(
                name: "FK_Calculations_Address_DestinationAddressId",
                schema: "dbo",
                table: "Calculations");

            migrationBuilder.DropForeignKey(
                name: "FK_Segments_Address_DepartureAddressId",
                schema: "dbo",
                table: "Segments");

            migrationBuilder.DropForeignKey(
                name: "FK_Segments_Address_DestinationAddressId",
                schema: "dbo",
                table: "Segments");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Address_AddressInfo",
                schema: "dbo",
                table: "Address");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                schema: "dbo",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "CargoSize",
                schema: "dbo",
                table: "Calculations");

            migrationBuilder.RenameTable(
                name: "Segments",
                schema: "dbo",
                newName: "Segments");

            migrationBuilder.RenameTable(
                name: "Calculations",
                schema: "dbo",
                newName: "Calculations");

            migrationBuilder.RenameTable(
                name: "Address",
                schema: "dbo",
                newName: "AddressSpecs");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_AddressSpecs_AddressInfo",
                table: "AddressSpecs",
                column: "AddressInfo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddressSpecs",
                table: "AddressSpecs",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Segments_AddressSpecs_DepartureAddressId",
                table: "Segments",
                column: "DepartureAddressId",
                principalTable: "AddressSpecs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Segments_AddressSpecs_DestinationAddressId",
                table: "Segments",
                column: "DestinationAddressId",
                principalTable: "AddressSpecs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
