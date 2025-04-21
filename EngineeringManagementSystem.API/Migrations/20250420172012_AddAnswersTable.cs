using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EngineeringManagementSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class AddAnswersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AssignedTo",
                table: "Questions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AssignedToUserId",
                table: "Questions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_AssignedToUserId",
                table: "Questions",
                column: "AssignedToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_DocumentId",
                table: "Questions",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ProjectId",
                table: "Questions",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ProjectId",
                table: "Documents",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Projects_ProjectId",
                table: "Documents",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Documents_DocumentId",
                table: "Questions",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Projects_ProjectId",
                table: "Questions",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Users_AssignedToUserId",
                table: "Questions",
                column: "AssignedToUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Projects_ProjectId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Documents_DocumentId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Projects_ProjectId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Users_AssignedToUserId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_AssignedToUserId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_DocumentId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_ProjectId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Documents_ProjectId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "AssignedTo",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "AssignedToUserId",
                table: "Questions");
        }
    }
}
