using DDD.Dominio.Interfaces.Servicos;
using DDD.DTO;
using DDD.Interfaces;
using System;
using System.Collections.Generic;

namespace DDD.Servicos
{
    public class ApplicationServicoAluno : IApplicationServicoAluno
    {
        private readonly IServicoAluno _servicoAluno;
        private readonly IMapperAluno _mapperAluno;

        public ApplicationServicoAluno(IServicoAluno ServiceAluno
                                        , MapperAluno MapperAluno)
        {
            _servicoAluno = ServiceAluno;
            _mapperAluno = MapperAluno;
        }

        public void Add(AlunoDTO obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AlunoDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public AlunoDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(AlunoDTO obj)
        {
            throw new NotImplementedException();
        }

        public void Update(AlunoDTO obj)
        {
            throw new NotImplementedException();
        }
    }
}
