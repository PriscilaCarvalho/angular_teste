using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace curso_priscila.Models
{
    public class Aluno
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AlunoId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public Guid CursoId { get; set; }
        public Curso Curso { get; set; }
    }
}
