using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimulacaoSeguroVeicular.Migrations
{
    /// <inheritdoc />
    public partial class ajustestatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "COTACOES",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Pendente",
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "COTACOES",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "Pendente");
        }
    }
}
