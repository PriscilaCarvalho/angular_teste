using curso_priscila.Models;
using Microsoft.EntityFrameworkCore;

namespace curso_priscila.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Curso> Curso { get; set; }
        //public DbSet<Enrollment> Enrollments { get; set; }
        //public DbSet<Student> Students { get; set; }
        //public DbSet<Department> Departments { get; set; }
        //public DbSet<Instructor> Instructors { get; set; }
        //public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        //public DbSet<CourseAssignment> CourseAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>() // entidade que será sobrescrito a forma de relacionamento via Fluent
                .HasOne<Curso>(a => a.Curso)  // UMA entidade Aluno, tem relacionamento com UM curso
                .WithMany(c => c.Alunos) // UMA entidade Curso, tem relacionamento com MUITOS Alunos
                .HasForeignKey(a => a.CursoId); // entidade aluno tem chave estrangeira de Curso 
                //.OnDelete(DeleteBehavior.Cascade);  // caso seja deletado uma linha da entidade Curso, 
                        // todos os alunos associados a entidade Curso deletado, seram removidos automaticamente

            modelBuilder.Entity<Curso>()
                .Property(c => c.Data)
                .ValueGeneratedOnAdd();

            //modelBuilder.Entity<Aluno>().ToTable("Curso");
            //modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            //modelBuilder.Entity<Student>().ToTable("Student");
            //modelBuilder.Entity<Department>().ToTable("Department");
            //modelBuilder.Entity<Instructor>().ToTable("Instructor");
            //modelBuilder.Entity<OfficeAssignment>().ToTable("OfficeAssignment");
            //modelBuilder.Entity<CourseAssignment>().ToTable("CourseAssignment");

            //modelBuilder.Entity<CourseAssignment>()
            //    .HasKey(c => new { c.CourseID, c.InstructorID });
        }
        //public DbSet<Enrollment> Enrollments { get; set; }
        //public DbSet<Student> Students { get; set; }
        //public DbSet<Department> Departments { get; set; }
        //public DbSet<Instructor> Instructors { get; set; }
        //public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        //public DbSet<CourseAssignment> CourseAssignments { get; set; }

        
    }
}