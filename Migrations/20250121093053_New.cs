using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webbshopen.Migrations
{
    /// <inheritdoc />
    public partial class New : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategorier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KategoriId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profiler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    forNamn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    efterNamn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    losenord = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Admin = table.Column<bool>(type: "bit", nullable: false),
                    ProfilerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiler_Profiler_ProfilerId",
                        column: x => x.ProfilerId,
                        principalTable: "Profiler",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pris = table.Column<int>(type: "int", nullable: false),
                    Antal = table.Column<int>(type: "int", nullable: false),
                    levrantör = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KategorierId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Kategorier_KategorierId",
                        column: x => x.KategorierId,
                        principalTable: "Kategorier",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_KategorierId",
                table: "Products",
                column: "KategorierId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiler_ProfilerId",
                table: "Profiler",
                column: "ProfilerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Profiler");

            migrationBuilder.DropTable(
                name: "Kategorier");
        }
    }
}
