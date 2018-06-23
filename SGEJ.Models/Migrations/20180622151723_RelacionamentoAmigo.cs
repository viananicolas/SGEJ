using Microsoft.EntityFrameworkCore.Migrations;

namespace SGEJ.Models.Migrations
{
    public partial class RelacionamentoAmigo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AmigoId",
                table: "Emprestimo",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimo_AmigoId",
                table: "Emprestimo",
                column: "AmigoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Emprestimo_Amigo_AmigoId",
                table: "Emprestimo",
                column: "AmigoId",
                principalTable: "Amigo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emprestimo_Amigo_AmigoId",
                table: "Emprestimo");

            migrationBuilder.DropIndex(
                name: "IX_Emprestimo_AmigoId",
                table: "Emprestimo");

            migrationBuilder.DropColumn(
                name: "AmigoId",
                table: "Emprestimo");
        }
    }
}
