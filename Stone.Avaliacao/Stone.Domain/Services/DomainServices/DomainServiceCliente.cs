using Stone.Domain.Contracts.Repository;
using Stone.Domain.Contracts.Services;
using Stone.Domain.Model.Entities;

namespace Stone.Domain.Services.DomainServices
{
    public class DomainServiceCliente : DomainServiceBase<Cliente, int>, IDomainServiceCliente
    {
        private readonly IRepositoryCliente _repositorio;

        public DomainServiceCliente(IRepositoryCliente repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }

        // todo: regra para autenticar um cliente

        // todo: regra para incluir um novo cliente

        // todo: regra para verificar limite de crédito disponível do cliente para transação
    }
}
