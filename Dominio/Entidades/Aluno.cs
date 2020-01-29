using DDD.Dominio.Entidades;
using System;

namespace DDD.Entidades
{
    public class Aluno : Base
    {                
        public string Email { get; set; }
        public Guid CursoId { get; set; }
        public Curso Curso { get; set; }
    }
}
