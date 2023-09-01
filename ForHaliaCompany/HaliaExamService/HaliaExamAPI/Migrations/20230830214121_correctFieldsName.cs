using Microsoft.EntityFrameworkCore.Migrations;

namespace HaliaExamAPI.Migrations
{
    public partial class correctFieldsName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assignedcases_cases_CaseId",
                table: "assignedcases");

            migrationBuilder.DropForeignKey(
                name: "FK_assignedcases_users_UserId",
                table: "assignedcases");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "assignedcases",
                newName: "userid");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "assignedcases",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "assignedcases",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "CaseId",
                table: "assignedcases",
                newName: "caseid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "assignedcases",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_assignedcases_UserId",
                table: "assignedcases",
                newName: "IX_assignedcases_userid");

            migrationBuilder.RenameIndex(
                name: "IX_assignedcases_CaseId",
                table: "assignedcases",
                newName: "IX_assignedcases_caseid");

            migrationBuilder.AddForeignKey(
                name: "FK_assignedcases_cases_caseid",
                table: "assignedcases",
                column: "caseid",
                principalTable: "cases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_assignedcases_users_userid",
                table: "assignedcases",
                column: "userid",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assignedcases_cases_caseid",
                table: "assignedcases");

            migrationBuilder.DropForeignKey(
                name: "FK_assignedcases_users_userid",
                table: "assignedcases");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "assignedcases",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "assignedcases",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "assignedcases",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "caseid",
                table: "assignedcases",
                newName: "CaseId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "assignedcases",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_assignedcases_userid",
                table: "assignedcases",
                newName: "IX_assignedcases_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_assignedcases_caseid",
                table: "assignedcases",
                newName: "IX_assignedcases_CaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_assignedcases_cases_CaseId",
                table: "assignedcases",
                column: "CaseId",
                principalTable: "cases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_assignedcases_users_UserId",
                table: "assignedcases",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
