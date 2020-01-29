using DDD.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mapping
{
    public class AlunoMap : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("Aluno");

            builder // entidade que será sobrescrito a forma de relacionamento via Fluent
                .HasOne<Curso>(a => a.Curso)  // UMA entidade Aluno, tem relacionamento com UM curso
                .WithMany(c => c.Alunos) // UMA entidade Curso, tem relacionamento com MUITOS Alunos
                .HasForeignKey(a => a.CursoId); // entidade aluno tem chave estrangeira de Curso 
                                                //.OnDelete(DeleteBehavior.Cascade);  // caso seja deletado uma linha da entidade Curso, 
                                                // todos os alunos associados a entidade Curso deletado, seram removidos automaticamente
        }
    }
}
