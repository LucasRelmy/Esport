using Microsoft.EntityFrameworkCore.Migrations;

namespace Esport.Data.Migrations
{
    public partial class CreationModelsMk2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipe",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipe", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Licencie",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(nullable: true),
                    Prenom = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licencie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Personnel",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(nullable: true),
                    Prenom = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CompoEquipe",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicencieID = table.Column<int>(nullable: false),
                    EquipeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompoEquipe", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CompoEquipe_Equipe_EquipeID",
                        column: x => x.EquipeID,
                        principalTable: "Equipe",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompoEquipe_Licencie_LicencieID",
                        column: x => x.LicencieID,
                        principalTable: "Licencie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompoEquipe_EquipeID",
                table: "CompoEquipe",
                column: "EquipeID");

            migrationBuilder.CreateIndex(
                name: "IX_CompoEquipe_LicencieID",
                table: "CompoEquipe",
                column: "LicencieID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompoEquipe");

            migrationBuilder.DropTable(
                name: "Personnel");

            migrationBuilder.DropTable(
                name: "Equipe");

            migrationBuilder.DropTable(
                name: "Licencie");
        }
    }
}
