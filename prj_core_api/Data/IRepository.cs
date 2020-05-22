using System.Threading.Tasks;
using prj_core_api.Models;

namespace prj_core_api.Data
{
    public interface IRepository
    {
        void Incluir<T>(T entidade) where T: class;
        void Alterar<T>(T entidade) where T: class;
        void Excluir<T>(T entidade) where T: class;
        Task<bool> SalvarAlteracoesAsync();

        //Aluno
        Task<Aluno[]> GetAllAlunos(bool incluiProfessor);
        Task<Aluno[]> GetAllAlunosByProfessorId(int ProfessorId, bool incluiProfessor);
        Task<Aluno> GetAllAlunoById(int AlunoId, bool incluiProfessor);
        
        // Professor
        Task<Professor[]> GetAllProfessores(bool incluiAluno);
        Task<Professor> GetAllProfessorById(int ProfessorId, bool incluiAluno);

    }
}