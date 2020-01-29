using DDD.Dominio.Interfaces.Repositorios;
using DDD.Dominio.Interfaces.Servicos;
using DDD.Entidades;

namespace Dominio.Servicos
{
    public class ServicoAluno : ServicoBase<Aluno>, IServicoAluno
    {
        public readonly IRepositorioAluno _repositorioAluno;

        public ServicoAluno(IRepositorioAluno RepositorioAluno)
            : base(RepositorioAluno)
        {
            _repositorioAluno = RepositorioAluno;
        }
    }
}
