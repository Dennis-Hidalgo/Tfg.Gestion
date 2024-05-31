using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tfg.Gestion.Migrations
{
    /// <inheritdoc />
    public partial class Corrected_Providers_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RawMaterials_Providers_ProductProviderId",
                table: "RawMaterials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Providers",
                table: "Providers");

            migrationBuilder.RenameTable(
                name: "Providers",
                newName: "ProductProviders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductProviders",
                table: "ProductProviders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RawMaterials_ProductProviders_ProductProviderId",
                table: "RawMaterials",
                column: "ProductProviderId",
                principalTable: "ProductProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RawMaterials_ProductProviders_ProductProviderId",
                table: "RawMaterials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductProviders",
                table: "ProductProviders");

            migrationBuilder.RenameTable(
                name: "ProductProviders",
                newName: "Providers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Providers",
                table: "Providers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RawMaterials_Providers_ProductProviderId",
                table: "RawMaterials",
                column: "ProductProviderId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
