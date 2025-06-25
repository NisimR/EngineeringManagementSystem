using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EngineeringManagementSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class AddProductionItemIdColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Documents",
                table: "ProductionProjects",
                newName: "ProductionItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductionItemId",
                table: "ProductionProjects",
                newName: "Documents");
        }
    }
}
