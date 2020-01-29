using DDD.Dominio.Interfaces.Repositorios;
using DDD.Dominio.Interfaces.Servicos;
using DDD.Entidades;

namespace Dominio.Servicos
{
    public class ServicoCurso : ServicoBase<Curso>, IServicoCurso
    {
        public readonly IRespositorioCurso _respositorioCurso;
        public ServicoCurso(IRespositorioCurso RespositorioCurso) : base(RespositorioCurso)
        {
            _respositorioCurso = RespositorioCurso;
        }
    }
}
