using System.Collections.Generic;

namespace prj_core_api.Models
{
    public class Professor
    {
        public int ProfessorId { get; set; }
        public string Nome { get; set; }
        public List<Aluno> Alunos { get; set; }
    }
}