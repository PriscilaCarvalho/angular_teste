using System;
using System.Linq;
using DDD.Models;

namespace DDD.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Alunos.
            if (context.Aluno.Any())
            {
                return;   // DB has been seeded
            }

            var alunos = new Aluno[]
            {
                new Aluno { Nome = "Priscila 1", AlunoId = Guid.NewGuid(), Email = "priscila1@teste.com.br" },
                new Aluno { Nome = "Priscila 2", AlunoId = Guid.NewGuid(), Email = "priscila2@teste.com.br" },
                new Aluno { Nome = "Priscila 3", AlunoId = Guid.NewGuid(), Email = "priscila3@teste.com.br" },
                new Aluno { Nome = "Priscila 4", AlunoId = Guid.NewGuid(), Email = "priscila4@teste.com.br" },
                new Aluno { Nome = "Priscila 5", AlunoId = Guid.NewGuid(), Email = "priscila5@teste.com.br" },
                new Aluno { Nome = "Priscila 6", AlunoId = Guid.NewGuid(), Email = "priscila6@teste.com.br" }
            };

            foreach (Aluno s in alunos)
            {
                context.Aluno.Add(s);
            }
            context.SaveChanges();
        }
    }
}