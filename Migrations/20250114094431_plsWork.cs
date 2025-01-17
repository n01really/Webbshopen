using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webbshopen.Migrations
{
    /// <inheritdoc />
    public partial class plsWork : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "lösenord",
                table: "Profiler",
                newName: "losenord");

            migrationBuilder.RenameColumn(
                name: "förNamn",
                table: "Profiler",
                newName: "forNamn");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "losenord",
                table: "Profiler",
                newName: "lösenord");

            migrationBuilder.RenameColumn(
                name: "forNamn",
                table: "Profiler",
                newName: "förNamn");
        }
    }
}
