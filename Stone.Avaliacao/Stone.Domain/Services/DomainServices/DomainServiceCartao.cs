using Stone.Domain.Contracts.Repository;
using Stone.Domain.Contracts.Services;
using Stone.Domain.Model.Entities;

namespace Stone.Domain.Services.DomainServices
{
    public class DomainServiceCartao : DomainServiceBase<Cartao, int>, IDomainServiceCartao
    {
        private readonly IRepositoryCartao _repositorio;

        public DomainServiceCartao(IRepositoryCartao repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }
    }
}
