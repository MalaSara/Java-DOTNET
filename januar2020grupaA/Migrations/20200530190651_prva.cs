using Microsoft.EntityFrameworkCore.Migrations;

namespace januar2020grupaA.Migrations
{
    public partial class prva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fabrike",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabrike", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Silosi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kapaciteti = table.Column<int>(nullable: false),
                    FabrikaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Silosi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Silosi_Fabrike_FabrikaId",
                        column: x => x.FabrikaId,
                        principalTable: "Fabrike",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Silosi_FabrikaId",
                table: "Silosi",
                column: "FabrikaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Silosi");

            migrationBuilder.DropTable(
                name: "Fabrike");
        }
    }
}
