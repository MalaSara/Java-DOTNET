using Microsoft.EntityFrameworkCore.Migrations;

namespace januar2020grupaB.Migrations
{
    public partial class prva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Biblioteke",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biblioteke", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Police",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    MaksBroj = table.Column<int>(nullable: false),
                    TrenutniBroj = table.Column<int>(nullable: false),
                    BibliotekaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Police", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Police_Biblioteke_BibliotekaId",
                        column: x => x.BibliotekaId,
                        principalTable: "Biblioteke",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Police_BibliotekaId",
                table: "Police",
                column: "BibliotekaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Police");

            migrationBuilder.DropTable(
                name: "Biblioteke");
        }
    }
}
