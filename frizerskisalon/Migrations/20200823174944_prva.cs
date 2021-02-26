using Microsoft.EntityFrameworkCore.Migrations;

namespace frizerskisalon.Migrations
{
    public partial class prva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Saloni",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imesalona = table.Column<string>(nullable: true),
                    Lokacija = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saloni", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Radnici",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imeradnik = table.Column<string>(nullable: true),
                    Vreme = table.Column<string>(nullable: true),
                    FrizerskisalonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radnici", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Radnici_Saloni_FrizerskisalonId",
                        column: x => x.FrizerskisalonId,
                        principalTable: "Saloni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Radnici_FrizerskisalonId",
                table: "Radnici",
                column: "FrizerskisalonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Radnici");

            migrationBuilder.DropTable(
                name: "Saloni");
        }
    }
}
