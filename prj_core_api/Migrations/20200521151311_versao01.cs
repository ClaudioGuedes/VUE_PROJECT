using Microsoft.EntityFrameworkCore.Migrations;

namespace prj_core_api.Migrations
{
    public partial class versao01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    ProfessorId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.ProfessorId);
                });

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    AlunoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    DtNascimento = table.Column<string>(nullable: true),
                    ProfessorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.AlunoId);
                    table.ForeignKey(
                        name: "FK_Alunos_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "ProfessorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "ProfessorId", "Nome" },
                values: new object[] { 1, "Claudio" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "ProfessorId", "Nome" },
                values: new object[] { 2, "Silvana" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "ProfessorId", "Nome" },
                values: new object[] { 3, "Hanna" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "AlunoId", "DtNascimento", "Nome", "ProfessorId", "Sobrenome" },
                values: new object[] { 1, "01/01/2000", "Daniel", 1, "Silva" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "AlunoId", "DtNascimento", "Nome", "ProfessorId", "Sobrenome" },
                values: new object[] { 2, "01/01/2000", "João", 2, "Queiroz" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "AlunoId", "DtNascimento", "Nome", "ProfessorId", "Sobrenome" },
                values: new object[] { 3, "01/01/2000", "Hanna", 3, "Silva" });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_ProfessorId",
                table: "Alunos",
                column: "ProfessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
