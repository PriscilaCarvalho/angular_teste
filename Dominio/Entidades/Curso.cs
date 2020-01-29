using DDD.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDD.Entidades
{
    public class Curso : Base
    {                
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Data { get; set; }
        public ICollection<Aluno> Alunos { get; set; }
    }
}
