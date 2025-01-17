using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webbshopen.Migrations
{
    /// <inheritdoc />
    public partial class producter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Antal",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "levrantör",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Antal",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "levrantör",
                table: "Products");
        }
    }
}
