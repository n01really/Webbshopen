using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webbshopen.Migrations
{
    /// <inheritdoc />
    public partial class sistaupp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiler_Profiler_ProfilerId",
                table: "Profiler");

            migrationBuilder.DropIndex(
                name: "IX_Profiler_ProfilerId",
                table: "Profiler");

            migrationBuilder.DropColumn(
                name: "ProfilerId",
                table: "Profiler");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfilerId",
                table: "Profiler",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profiler_ProfilerId",
                table: "Profiler",
                column: "ProfilerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiler_Profiler_ProfilerId",
                table: "Profiler",
                column: "ProfilerId",
                principalTable: "Profiler",
                principalColumn: "Id");
        }
    }
}
