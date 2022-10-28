using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoletimOnline.Api.Migrations
{
    public partial class AddCollumCourseToStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCourse",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdCourse",
                table: "Student");
        }
    }
}
