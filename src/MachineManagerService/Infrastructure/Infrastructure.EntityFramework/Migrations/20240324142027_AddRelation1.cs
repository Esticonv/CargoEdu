using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace R7P.MachineManagerService.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddRelation1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MachineTasks",
                table: "MachineTasks");

            migrationBuilder.DropIndex(
                name: "IX_MachineTasks_MachineId",
                table: "MachineTasks");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "MachineTasks",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MachineTasks",
                table: "MachineTasks",
                columns: new[] { "MachineId", "TaskOrder" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MachineTasks",
                table: "MachineTasks");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "MachineTasks",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MachineTasks",
                table: "MachineTasks",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_MachineTasks_MachineId",
                table: "MachineTasks",
                column: "MachineId");
        }
    }
}
