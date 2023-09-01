using Microsoft.EntityFrameworkCore.Migrations;

namespace HaliaExamAPI.Migrations
{
    public partial class CorrectFieldsNameUserCaseStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_casesstatus_cases_CaseId",
                table: "casesstatus");

            migrationBuilder.DropForeignKey(
                name: "FK_casesstatus_users_ActionedUserId",
                table: "casesstatus");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "users",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "users",
                newName: "lastname");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "users",
                newName: "firstname");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_users_Phone",
                table: "users",
                newName: "IX_users_phone");

            migrationBuilder.RenameIndex(
                name: "IX_users_Email",
                table: "users",
                newName: "IX_users_email");

            migrationBuilder.RenameColumn(
                name: "StatusDescription",
                table: "casesstatus",
                newName: "statusdescription");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "casesstatus",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "casesstatus",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "CaseId",
                table: "casesstatus",
                newName: "caseid");

            migrationBuilder.RenameColumn(
                name: "ActionedUserId",
                table: "casesstatus",
                newName: "actioneduserid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "casesstatus",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_casesstatus_CaseId",
                table: "casesstatus",
                newName: "IX_casesstatus_caseid");

            migrationBuilder.RenameIndex(
                name: "IX_casesstatus_ActionedUserId",
                table: "casesstatus",
                newName: "IX_casesstatus_actioneduserid");

            migrationBuilder.AddForeignKey(
                name: "FK_casesstatus_cases_caseid",
                table: "casesstatus",
                column: "caseid",
                principalTable: "cases",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_casesstatus_users_actioneduserid",
                table: "casesstatus",
                column: "actioneduserid",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_casesstatus_cases_caseid",
                table: "casesstatus");

            migrationBuilder.DropForeignKey(
                name: "FK_casesstatus_users_actioneduserid",
                table: "casesstatus");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "users",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "lastname",
                table: "users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "firstname",
                table: "users",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "users",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_users_phone",
                table: "users",
                newName: "IX_users_Phone");

            migrationBuilder.RenameIndex(
                name: "IX_users_email",
                table: "users",
                newName: "IX_users_Email");

            migrationBuilder.RenameColumn(
                name: "statusdescription",
                table: "casesstatus",
                newName: "StatusDescription");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "casesstatus",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "casesstatus",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "caseid",
                table: "casesstatus",
                newName: "CaseId");

            migrationBuilder.RenameColumn(
                name: "actioneduserid",
                table: "casesstatus",
                newName: "ActionedUserId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "casesstatus",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_casesstatus_caseid",
                table: "casesstatus",
                newName: "IX_casesstatus_CaseId");

            migrationBuilder.RenameIndex(
                name: "IX_casesstatus_actioneduserid",
                table: "casesstatus",
                newName: "IX_casesstatus_ActionedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_casesstatus_cases_CaseId",
                table: "casesstatus",
                column: "CaseId",
                principalTable: "cases",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_casesstatus_users_ActionedUserId",
                table: "casesstatus",
                column: "ActionedUserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
