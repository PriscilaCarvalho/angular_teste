using DDD.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Interfaces
{
    public interface IApplicationServicoCurso
    {
        void Add(CursoDTO obj);

        CursoDTO GetById(int id);

        IEnumerable<CursoDTO> GetAll();

        void Update(CursoDTO obj);

        void Remove(CursoDTO obj);

        void Dispose();
    }
}
