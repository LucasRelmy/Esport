using Microsoft.EntityFrameworkCore.Migrations;

namespace Esport.Data.Migrations
{
    public partial class AjoutValidateEquipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Validate",
                table: "Equipe",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Validate",
                table: "Equipe");
        }
    }
}
