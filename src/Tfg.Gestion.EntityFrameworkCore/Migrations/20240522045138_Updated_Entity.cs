using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tfg.Gestion.Migrations
{
    /// <inheritdoc />
    public partial class Updated_Entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Products");
        }
    }
}
