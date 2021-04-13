using Microsoft.EntityFrameworkCore.Migrations;

namespace Esport.Data.Migrations
{
    public partial class mk1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PhaseID",
                table: "Competition",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Phase",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phase", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Competition_PhaseID",
                table: "Competition",
                column: "PhaseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Competition_Phase_PhaseID",
                table: "Competition",
                column: "PhaseID",
                principalTable: "Phase",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competition_Phase_PhaseID",
                table: "Competition");

            migrationBuilder.DropTable(
                name: "Phase");

            migrationBuilder.DropIndex(
                name: "IX_Competition_PhaseID",
                table: "Competition");

            migrationBuilder.DropColumn(
                name: "PhaseID",
                table: "Competition");
        }
    }
}
