using System.Threading.Tasks;
using prj_core_api.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace prj_core_api.Data
{
  public class Repository : IRepository
  {
    public DataContext _context { get; }
    public Repository(DataContext context){
      _context = context;
    }

    public void Alterar<T>(T entidade) where T : class
    {
      _context.Update(entidade);
    }

    public void Excluir<T>(T entidade) where T : class
    {
      _context.Remove(entidade);
    }

    public void Incluir<T>(T entidade) where T : class
    {
      _context.Add(entidade);
    }

    public async Task<bool> SalvarAlteracoesAsync()
    {
      return (await _context.SaveChangesAsync() > 0);
    }

    // ALUNOS
    public async Task<Aluno[]> GetAllAlunos(bool incluirProfessor = false)
    {
      try
      {
          IQueryable<Aluno> query = _context.Alunos;
          if (incluirProfessor)
          {
              query = query.Include(a => a.Professor);
          }
          query = query.AsNoTracking().OrderBy(a => a.Nome);
          return await query.ToArrayAsync();
      }
      catch (System.Exception ex)
      {
          throw ex;
      }
    }

    public async Task<Aluno[]> GetAllAlunosByProfessorId(int id, bool incluirProfessor = false)
    {
      try
      {
          IQueryable<Aluno> query = _context.Alunos;
          if (incluirProfessor)
          {
              query = query.Include(a => a.Professor);
          }
          query = query.AsNoTracking().Where(a => a.Professor.ProfessorId == id);
          return await query.ToArrayAsync();
      }
      catch (System.Exception ex)
      {
          throw ex;
      }
    }

    public async Task<Aluno> GetAllAlunoById(int id, bool incluirProfessor = false)
    {
      try
      {
          IQueryable<Aluno> query = _context.Alunos;
          if (incluirProfessor)
          {
              query = query.Include(a => a.Professor);
          }
          query = query.AsNoTracking().Where(a => a.AlunoId == id);
          return await query.FirstOrDefaultAsync();
      }
      catch (System.Exception ex)
      {
          throw ex;
      }
    }

    // PROFESSORES
    public async Task<Professor[]> GetAllProfessores(bool incluirAluno = false)
    {
      try
      {
          IQueryable<Professor> query = _context.Professores;
          if (incluirAluno)
          {
              query = query.Include(p => p.Alunos);
          }
          query = query.AsNoTracking().OrderBy(p => p.Nome);
          return await query.ToArrayAsync();
      }
      catch (System.Exception ex)
      {
          throw ex;
      }
    }

    public async Task<Professor> GetAllProfessorById(int id, bool incluirAluno =false)
    {
     try
      {
          IQueryable<Professor> query = _context.Professores;
          if (incluirAluno)
          {
              query = query.Include(p => p.Alunos);
          }
          query = query.AsNoTracking().Where(p => p.ProfessorId == id);
          return await query.FirstOrDefaultAsync();
      }
      catch (System.Exception ex)
      {
          throw ex;
      }
    }
  }
}