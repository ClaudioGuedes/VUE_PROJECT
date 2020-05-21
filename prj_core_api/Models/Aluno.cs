namespace prj_core_api.Models
{
    public class Aluno
    {
        public int AlunoId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string DtNascimento { get; set; }
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }

    }
}