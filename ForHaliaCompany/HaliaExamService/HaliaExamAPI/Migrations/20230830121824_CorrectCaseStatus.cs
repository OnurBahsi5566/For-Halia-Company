using Microsoft.EntityFrameworkCore.Migrations;

namespace HaliaExamAPI.Migrations
{
    public partial class CorrectCaseStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActionedUserId",
                table: "CasesStatus",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CasesStatus_ActionedUserId",
                table: "CasesStatus",
                column: "ActionedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CasesStatus_Users_ActionedUserId",
                table: "CasesStatus",
                column: "ActionedUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CasesStatus_Users_ActionedUserId",
                table: "CasesStatus");

            migrationBuilder.DropIndex(
                name: "IX_CasesStatus_ActionedUserId",
                table: "CasesStatus");

            migrationBuilder.DropColumn(
                name: "ActionedUserId",
                table: "CasesStatus");
        }
    }
}
