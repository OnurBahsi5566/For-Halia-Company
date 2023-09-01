using Microsoft.EntityFrameworkCore.Migrations;

namespace HaliaExamAPI.Migrations
{
    public partial class CorrectCaseFieldsName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "cases",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "cases",
                newName: "startDate");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "cases",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "FinishDate",
                table: "cases",
                newName: "finishDate");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "cases",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "cases",
                newName: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status",
                table: "cases",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "startDate",
                table: "cases",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "cases",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "finishDate",
                table: "cases",
                newName: "FinishDate");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "cases",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "cases",
                newName: "Id");
        }
    }
}
