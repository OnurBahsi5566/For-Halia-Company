using Microsoft.EntityFrameworkCore.Migrations;

namespace HaliaExamAPI.Migrations
{
    public partial class casesCorrect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "startDate",
                table: "cases",
                newName: "startdate");

            migrationBuilder.RenameColumn(
                name: "finishDate",
                table: "cases",
                newName: "finishdate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "startdate",
                table: "cases",
                newName: "startDate");

            migrationBuilder.RenameColumn(
                name: "finishdate",
                table: "cases",
                newName: "finishDate");
        }
    }
}
