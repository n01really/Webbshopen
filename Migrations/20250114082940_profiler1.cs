using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webbshopen.Migrations
{
    /// <inheritdoc />
    public partial class profiler1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profiler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    förNamn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    efterNamn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lösenord = table.Column<string>(type: "nvarchar(max)", nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_Profiler_ProfilerId",
                table: "Profiler",
                column: "ProfilerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Profiler");
        }
    }
}
