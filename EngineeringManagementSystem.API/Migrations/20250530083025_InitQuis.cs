using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EngineeringManagementSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class InitQuis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DocumentRevisionId",
                table: "Questions",
                newName: "DocumentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DocumentId",
                table: "Questions",
                newName: "DocumentRevisionId");
        }
    }
}
