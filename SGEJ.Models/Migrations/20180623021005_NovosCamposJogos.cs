using Microsoft.EntityFrameworkCore.Migrations;

namespace SGEJ.Models.Migrations
{
    public partial class NovosCamposJogos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Desenvolvedora",
                table: "Jogo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Distribuidora",
                table: "Jogo",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Plataforma",
                table: "Jogo",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desenvolvedora",
                table: "Jogo");

            migrationBuilder.DropColumn(
                name: "Distribuidora",
                table: "Jogo");

            migrationBuilder.DropColumn(
                name: "Plataforma",
                table: "Jogo");
        }
    }
}
