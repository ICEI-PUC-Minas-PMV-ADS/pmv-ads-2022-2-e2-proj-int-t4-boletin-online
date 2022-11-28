using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoletimOnline.Api.Migrations
{
    public partial class criandoNota2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nota",
                columns: table => new
                {
                    Id_nota = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CursoId = table.Column<int>(type: "int", nullable: false),
                    DisciplinaId = table.Column<int>(type: "int", nullable: false),
                    ProfessorId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    Vl_nota = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nota", x => x.Id_nota);
                    table.ForeignKey(
                        name: "FK_Nota_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nota_Disciplina_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nota_Professor_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nota_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nota_CursoId",
                table: "Nota",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Nota_DisciplinaId",
                table: "Nota",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Nota_ProfessorId",
                table: "Nota",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Nota_StudentId",
                table: "Nota",
                column: "StudentId");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
