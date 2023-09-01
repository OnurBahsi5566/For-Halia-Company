using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HaliaExamAPI.Migrations
{
    public partial class pstgreSqlFormat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignedCases_Cases_CaseId",
                table: "AssignedCases");

            migrationBuilder.DropForeignKey(
                name: "FK_AssignedCases_Users_UserId",
                table: "AssignedCases");

            migrationBuilder.DropForeignKey(
                name: "FK_CasesStatus_Cases_CaseId",
                table: "CasesStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_CasesStatus_Users_ActionedUserId",
                table: "CasesStatus");

            migrationBuilder.DropTable(
                name: "musteriler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CasesStatus",
                table: "CasesStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cases",
                table: "Cases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssignedCases",
                table: "AssignedCases");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "CasesStatus",
                newName: "casesstatus");

            migrationBuilder.RenameTable(
                name: "Cases",
                newName: "cases");

            migrationBuilder.RenameTable(
                name: "AssignedCases",
                newName: "assignedcases");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Phone",
                table: "users",
                newName: "IX_users_Phone");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Email",
                table: "users",
                newName: "IX_users_Email");

            migrationBuilder.RenameIndex(
                name: "IX_CasesStatus_CaseId",
                table: "casesstatus",
                newName: "IX_casesstatus_CaseId");

            migrationBuilder.RenameIndex(
                name: "IX_CasesStatus_ActionedUserId",
                table: "casesstatus",
                newName: "IX_casesstatus_ActionedUserId");

            migrationBuilder.RenameIndex(
                name: "IX_AssignedCases_UserId",
                table: "assignedcases",
                newName: "IX_assignedcases_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AssignedCases_CaseId",
                table: "assignedcases",
                newName: "IX_assignedcases_CaseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_casesstatus",
                table: "casesstatus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cases",
                table: "cases",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_assignedcases",
                table: "assignedcases",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_casesstatus_cases_CaseId",
                table: "casesstatus",
                column: "CaseId",
                principalTable: "cases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_casesstatus_users_ActionedUserId",
                table: "casesstatus",
                column: "ActionedUserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assignedcases_cases_CaseId",
                table: "assignedcases");

            migrationBuilder.DropForeignKey(
                name: "FK_assignedcases_users_UserId",
                table: "assignedcases");

            migrationBuilder.DropForeignKey(
                name: "FK_casesstatus_cases_CaseId",
                table: "casesstatus");

            migrationBuilder.DropForeignKey(
                name: "FK_casesstatus_users_ActionedUserId",
                table: "casesstatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_casesstatus",
                table: "casesstatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cases",
                table: "cases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_assignedcases",
                table: "assignedcases");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "casesstatus",
                newName: "CasesStatus");

            migrationBuilder.RenameTable(
                name: "cases",
                newName: "Cases");

            migrationBuilder.RenameTable(
                name: "assignedcases",
                newName: "AssignedCases");

            migrationBuilder.RenameIndex(
                name: "IX_users_Phone",
                table: "Users",
                newName: "IX_Users_Phone");

            migrationBuilder.RenameIndex(
                name: "IX_users_Email",
                table: "Users",
                newName: "IX_Users_Email");

            migrationBuilder.RenameIndex(
                name: "IX_casesstatus_CaseId",
                table: "CasesStatus",
                newName: "IX_CasesStatus_CaseId");

            migrationBuilder.RenameIndex(
                name: "IX_casesstatus_ActionedUserId",
                table: "CasesStatus",
                newName: "IX_CasesStatus_ActionedUserId");

            migrationBuilder.RenameIndex(
                name: "IX_assignedcases_UserId",
                table: "AssignedCases",
                newName: "IX_AssignedCases_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_assignedcases_CaseId",
                table: "AssignedCases",
                newName: "IX_AssignedCases_CaseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CasesStatus",
                table: "CasesStatus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cases",
                table: "Cases",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssignedCases",
                table: "AssignedCases",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "musteriler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_musteriler", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedCases_Cases_CaseId",
                table: "AssignedCases",
                column: "CaseId",
                principalTable: "Cases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedCases_Users_UserId",
                table: "AssignedCases",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CasesStatus_Cases_CaseId",
                table: "CasesStatus",
                column: "CaseId",
                principalTable: "Cases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CasesStatus_Users_ActionedUserId",
                table: "CasesStatus",
                column: "ActionedUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
