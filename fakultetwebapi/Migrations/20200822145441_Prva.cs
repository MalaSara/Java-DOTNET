using Microsoft.EntityFrameworkCore.Migrations;

namespace fakultetwebapi.Migrations
{
    public partial class Prva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fakulteti",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imefakulteta = table.Column<string>(nullable: true),
                    Lokacija = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fakulteti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Studenti",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imestudenta = table.Column<string>(nullable: true),
                    Indeks = table.Column<int>(nullable: false),
                    Predmeti = table.Column<string>(nullable: true),
                    FakultetId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studenti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Studenti_Fakulteti_FakultetId",
                        column: x => x.FakultetId,
                        principalTable: "Fakulteti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Studenti_FakultetId",
                table: "Studenti",
                column: "FakultetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Studenti");

            migrationBuilder.DropTable(
                name: "Fakulteti");
        }
    }
}
