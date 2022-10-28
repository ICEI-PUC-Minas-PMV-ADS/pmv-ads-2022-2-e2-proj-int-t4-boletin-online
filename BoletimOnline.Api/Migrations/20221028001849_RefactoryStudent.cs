using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoletimOnline.Api.Migrations
{
    public partial class RefactoryStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentName",
                table: "Student",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "StudentEnrollment",
                table: "Student",
                newName: "Enrollment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Student",
                newName: "StudentName");

            migrationBuilder.RenameColumn(
                name: "Enrollment",
                table: "Student",
                newName: "StudentEnrollment");
        }
    }
}
