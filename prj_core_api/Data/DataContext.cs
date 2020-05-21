using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using prj_core_api.Models;

namespace prj_core_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<Professor>()
                .HasData(
                    new List<Professor>() {
                        new Professor() {
                            ProfessorId = 1,
                            Nome = "Claudio",                            
                        },
                        new Professor() {
                            ProfessorId = 2,
                            Nome = "Silvana",                            
                        },
                        new Professor() {
                            ProfessorId = 3,
                            Nome = "Hanna",                            
                        },
                    }
                );

            builder.Entity<Aluno>()
                .HasData(
                    new List<Aluno>() {
                        new Aluno() {
                            AlunoId = 1,
                            Nome = "Daniel",
                            Sobrenome = "Silva",                         
                            DtNascimento = "01/01/2000",
                            ProfessorId = 1
                        },
                        new Aluno() {
                            AlunoId = 2,
                            Nome = "João",                            
                            Sobrenome = "Queiroz",                         
                            DtNascimento = "01/01/2000",
                            ProfessorId = 2
                        },
                        new Aluno() {
                            AlunoId = 3,
                            Nome = "Hanna",                            
                            Sobrenome = "Silva",                         
                            DtNascimento = "01/01/2000",
                            ProfessorId = 3
                        },
                    }
                );
        }
    }
}