using Microsoft.EntityFrameworkCore.Migrations;

namespace Esport.Data.Migrations
{
    public partial class AjoutValidateLicence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Validate",
                table: "Licencie",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Validate",
                table: "Licencie");
        }
    }
}
