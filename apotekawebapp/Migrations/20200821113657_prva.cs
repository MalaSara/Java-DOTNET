using Microsoft.EntityFrameworkCore.Migrations;

namespace apotekawebapp.Migrations
{
    public partial class prva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apoteke",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivApoteke = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apoteke", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lekovi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegBroj = table.Column<int>(nullable: false),
                    NazivLeka = table.Column<string>(nullable: true),
                    Cena = table.Column<int>(nullable: false),
                    Kolicina = table.Column<int>(nullable: false),
                    ApotekaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lekovi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lekovi_Apoteke_ApotekaId",
                        column: x => x.ApotekaId,
                        principalTable: "Apoteke",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lekovi_ApotekaId",
                table: "Lekovi",
                column: "ApotekaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lekovi");

            migrationBuilder.DropTable(
                name: "Apoteke");
        }
    }
}
