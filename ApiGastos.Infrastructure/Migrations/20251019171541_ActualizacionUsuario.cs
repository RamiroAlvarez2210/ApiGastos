using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiGastos.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ActualizacionUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Saldo",
                table: "Usuarios",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<decimal>(
                name: "AhorrosDolares",
                table: "Usuarios",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AhorrosPesos",
                table: "Usuarios",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AhorrosDolares",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "AhorrosPesos",
                table: "Usuarios");

            migrationBuilder.AlterColumn<int>(
                name: "Saldo",
                table: "Usuarios",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
