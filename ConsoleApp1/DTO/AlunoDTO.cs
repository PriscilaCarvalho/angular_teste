using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.DTO
{
    public class AlunoDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Guid CursoId { get; set; }        
    }
}
