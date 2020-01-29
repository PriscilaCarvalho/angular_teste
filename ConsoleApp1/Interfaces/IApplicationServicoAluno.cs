using DDD.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDD.Interfaces
{
    public interface IApplicationServicoAluno
    {
        void Add(AlunoDTO obj);

        AlunoDTO GetById(int id);

        IEnumerable<AlunoDTO> GetAll();

        void Update(AlunoDTO obj);

        void Remove(AlunoDTO obj);

        void Dispose();
    }
}
