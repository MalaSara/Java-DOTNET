using Microsoft.EntityFrameworkCore.Migrations;

namespace januar2020_bioskopi.Migrations
{
    public partial class prva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bioskopi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: false),
                    Red = table.Column<int>(nullable: false),
                    BrojMesta = table.Column<int>(nullable: false),
                    Rezervisanih = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bioskopi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stolice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BioskopId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stolice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stolice_Bioskopi_BioskopId",
                        column: x => x.BioskopId,
                        principalTable: "Bioskopi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stolice_BioskopId",
                table: "Stolice",
                column: "BioskopId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stolice");

            migrationBuilder.DropTable(
                name: "Bioskopi");
        }
    }
}
