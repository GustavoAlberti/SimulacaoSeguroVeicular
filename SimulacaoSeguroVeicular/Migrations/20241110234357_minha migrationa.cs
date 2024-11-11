using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimulacaoSeguroVeicular.Migrations
{
    /// <inheritdoc />
    public partial class minhamigrationa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "COTACOES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VeiculoMarca = table.Column<string>(type: "varchar(100)", nullable: false),
                    VeiculoModelo = table.Column<string>(type: "varchar(100)", nullable: false),
                    VeiculoAno = table.Column<int>(type: "int", nullable: false),
                    ProprietarioCpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    ProprietarioNome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProprietarioDataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProprietarioCep = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    ProprietarioRua = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProprietarioBairro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProprietarioCidade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProprietarioEstado = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    CondutorCpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    CondutorNome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CondutorDataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProponenteCep = table.Column<string>(type: "varchar(15)", nullable: false),
                    ProponenteRua = table.Column<string>(type: "varchar(100)", nullable: false),
                    ProponenteBairro = table.Column<string>(type: "varchar(50)", nullable: false),
                    ProponenteCidade = table.Column<string>(type: "varchar(150)", nullable: false),
                    ProponenteEstado = table.Column<string>(type: "varchar(2)", nullable: false),
                    CoberturaSelecionada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorSeguroTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataAprovacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValorMercadoFipe = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NivelDeRisco = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COTACOES", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "COTACOES");
        }
    }
}
