using Microsoft.EntityFrameworkCore.Migrations;

namespace HaliaExamAPI.Migrations
{
    public partial class updateCasesField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cases_users_openeduserid",
                table: "cases");

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "cases",
                type: "character varying(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<int>(
                name: "openeduserid",
                table: "cases",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

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
                name: "FK_cases_users_openeduserid",
                table: "cases");

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "cases",
                type: "character varying(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "openeduserid",
                table: "cases",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_cases_users_openeduserid",
                table: "cases",
                column: "openeduserid",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
