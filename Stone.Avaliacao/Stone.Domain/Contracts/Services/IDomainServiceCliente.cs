using Stone.Domain.Model.Entities;

namespace Stone.Domain.Contracts.Services
{
    public interface IDomainServiceCliente : IDomainServiceBase<Cliente, int>
    {
        bool ValidarCliente(string cliente, string password);
    }
}