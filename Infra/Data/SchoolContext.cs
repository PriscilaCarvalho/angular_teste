using DDD.Entidades;
using Infra.Mapping;
using Microsoft.EntityFrameworkCore;

namespace DDD.Data
{
    public class SchoolContext : DbContext
    {
        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Curso> Curso { get; set; }

        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Server=(localdb);mssqllocaldb;Database=SchoolContext;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Aluno>(new AlunoMap().Configure);
            modelBuilder.Entity<Curso>(new CursoMap().Configure);
        }

    }
}