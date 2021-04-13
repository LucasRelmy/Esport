using Microsoft.EntityFrameworkCore.Migrations;

namespace Esport.Data.Migrations
{
    public partial class Competitions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompetitionG",
                table: "Equipe",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompetitionP",
                table: "Equipe",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MancheG",
                table: "Equipe",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MancheP",
                table: "Equipe",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompetitionG",
                table: "Equipe");

            migrationBuilder.DropColumn(
                name: "CompetitionP",
                table: "Equipe");

            migrationBuilder.DropColumn(
                name: "MancheG",
                table: "Equipe");

            migrationBuilder.DropColumn(
                name: "MancheP",
                table: "Equipe");
        }
    }
}
