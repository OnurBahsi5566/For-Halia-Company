using Microsoft.EntityFrameworkCore.Migrations;

namespace HaliaExamAPI.Migrations
{
    public partial class SetTablesUserField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assignedcases_users_userid",
                table: "assignedcases");

            migrationBuilder.RenameColumn(
                name: "userid",
                table: "assignedcases",
                newName: "assigneduserid");

            migrationBuilder.RenameIndex(
                name: "IX_assignedcases_userid",
                table: "assignedcases",
                newName: "IX_assignedcases_assigneduserid");

            migrationBuilder.AddColumn<int>(
                name: "openeduserid",
                table: "cases",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "actioneduserid",
                table: "assignedcases",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_cases_openeduserid",
                table: "cases",
                column: "openeduserid");

            migrationBuilder.CreateIndex(
                name: "IX_assignedcases_actioneduserid",
                table: "assignedcases",
                column: "actioneduserid");

            migrationBuilder.AddForeignKey(
                name: "FK_assignedcases_users_actioneduserid",
                table: "assignedcases",
                column: "actioneduserid",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_assignedcases_users_assigneduserid",
                table: "assignedcases",
                column: "assigneduserid",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cases_users_openeduserid",
                table: "cases",
                column: "openeduserid",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assignedcases_users_actioneduserid",
                table: "assignedcases");

            migrationBuilder.DropForeignKey(
                name: "FK_assignedcases_users_assigneduserid",
                table: "assignedcases");

            migrationBuilder.DropForeignKey(
                name: "FK_cases_users_openeduserid",
                table: "cases");

            migrationBuilder.DropIndex(
                name: "IX_cases_openeduserid",
                table: "cases");

            migrationBuilder.DropIndex(
                name: "IX_assignedcases_actioneduserid",
                table: "assignedcases");

            migrationBuilder.DropColumn(
                name: "openeduserid",
                table: "cases");

            migrationBuilder.DropColumn(
                name: "actioneduserid",
                table: "assignedcases");

            migrationBuilder.RenameColumn(
                name: "assigneduserid",
                table: "assignedcases",
                newName: "userid");

            migrationBuilder.RenameIndex(
                name: "IX_assignedcases_assigneduserid",
                table: "assignedcases",
                newName: "IX_assignedcases_userid");

            migrationBuilder.AddForeignKey(
                name: "FK_assignedcases_users_userid",
                table: "assignedcases",
                column: "userid",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
