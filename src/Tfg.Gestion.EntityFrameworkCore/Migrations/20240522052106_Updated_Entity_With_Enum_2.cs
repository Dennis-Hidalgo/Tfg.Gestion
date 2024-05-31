using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tfg.Gestion.Migrations
{
    /// <inheritdoc />
    public partial class Updated_Entity_With_Enum_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Products",
                newName: "MyCategory");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MyCategory",
                table: "Products",
                newName: "Category");
        }
    }
}
