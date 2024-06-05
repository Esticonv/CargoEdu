using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace R7P.OrderService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCargoGuid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CargoGuid",
                schema: "dbo",
                table: "Orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CargoGuid",
                schema: "dbo",
                table: "Orders");
        }
    }
}
