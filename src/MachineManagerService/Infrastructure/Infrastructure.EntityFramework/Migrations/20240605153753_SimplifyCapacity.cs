using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace R7P.MachineManagerService.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class SimplifyCapacity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cargoes_Machines_MachineId",
                table: "Cargoes");

            migrationBuilder.DropColumn(
                name: "VolumeCapacity",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "Volume",
                table: "Cargoes");

            migrationBuilder.RenameColumn(
                name: "WeightCapacity",
                table: "Machines",
                newName: "Capacity");

            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "Cargoes",
                newName: "Size");

            migrationBuilder.AddColumn<long>(
                name: "CargoId",
                table: "MachineTasks",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "MachineId",
                table: "Cargoes",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "Destination",
                table: "Cargoes",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CargoGuid",
                table: "Cargoes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_MachineTasks_CargoId",
                table: "MachineTasks",
                column: "CargoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cargoes_Machines_MachineId",
                table: "Cargoes",
                column: "MachineId",
                principalTable: "Machines",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MachineTasks_Cargoes_CargoId",
                table: "MachineTasks",
                column: "CargoId",
                principalTable: "Cargoes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cargoes_Machines_MachineId",
                table: "Cargoes");

            migrationBuilder.DropForeignKey(
                name: "FK_MachineTasks_Cargoes_CargoId",
                table: "MachineTasks");

            migrationBuilder.DropIndex(
                name: "IX_MachineTasks_CargoId",
                table: "MachineTasks");

            migrationBuilder.DropColumn(
                name: "CargoId",
                table: "MachineTasks");

            migrationBuilder.DropColumn(
                name: "CargoGuid",
                table: "Cargoes");

            migrationBuilder.RenameColumn(
                name: "Capacity",
                table: "Machines",
                newName: "WeightCapacity");

            migrationBuilder.RenameColumn(
                name: "Size",
                table: "Cargoes",
                newName: "Weight");

            migrationBuilder.AddColumn<double>(
                name: "VolumeCapacity",
                table: "Machines",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<long>(
                name: "MachineId",
                table: "Cargoes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Destination",
                table: "Cargoes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<double>(
                name: "Volume",
                table: "Cargoes",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_Cargoes_Machines_MachineId",
                table: "Cargoes",
                column: "MachineId",
                principalTable: "Machines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
