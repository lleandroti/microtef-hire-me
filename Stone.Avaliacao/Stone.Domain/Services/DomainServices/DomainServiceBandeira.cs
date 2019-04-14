using Stone.Domain.Contracts.Repository;
using Stone.Domain.Contracts.Services;
using Stone.Domain.Model.Entities;

namespace Stone.Domain.Services.DomainServices
{
    public class DomainServiceBandeira : DomainServiceBase<Bandeira, int>, IDomainServiceBandeira
    {
        private readonly IRepositoryBandeira _repositorio;

        public DomainServiceBandeira(IRepositoryBandeira repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }
    }
}
