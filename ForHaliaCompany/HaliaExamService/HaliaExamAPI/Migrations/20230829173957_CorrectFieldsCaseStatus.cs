using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HaliaExamAPI.Migrations
{
    public partial class CorrectFieldsCaseStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "CasesStatus",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CaseId",
                table: "CasesStatus",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CasesStatus_CaseId",
                table: "CasesStatus",
                column: "CaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CasesStatus_Cases_CaseId",
                table: "CasesStatus",
                column: "CaseId",
                principalTable: "Cases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CasesStatus_Cases_CaseId",
                table: "CasesStatus");

            migrationBuilder.DropIndex(
                name: "IX_CasesStatus_CaseId",
                table: "CasesStatus");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "CasesStatus",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<int>(
                name: "CaseId",
                table: "CasesStatus",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");
        }
    }
}
