using Microsoft.EntityFrameworkCore.Migrations;

namespace jun2020_webapi.Migrations
{
    public partial class prva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mecevi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lokacija = table.Column<string>(nullable: true),
                    Listapoena = table.Column<string>(nullable: true),
                    Vreme = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mecevi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Igraci",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: true),
                    Godine = table.Column<int>(nullable: false),
                    Atprang = table.Column<int>(nullable: false),
                    Poeni = table.Column<int>(nullable: false),
                    MecId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Igraci", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Igraci_Mecevi_MecId",
                        column: x => x.MecId,
                        principalTable: "Mecevi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Igraci_MecId",
                table: "Igraci",
                column: "MecId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Igraci");

            migrationBuilder.DropTable(
                name: "Mecevi");
        }
    }
}
