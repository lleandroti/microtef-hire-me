using System.Linq;
using Stone.Domain.Contracts.Repository;
using Stone.Domain.Contracts.Services;
using Stone.Domain.Model.Entities;
using Stone.Framework.Security;

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

        public bool ValidarCliente(string cliente, string password)
        {
            var pwd = CriptografiaAESHelper.Descriptografar(password);

            var registro = _repositorio.FindAll().FirstOrDefault(x => x.Nome == cliente && x.Password == pwd);

            return registro != null ? registro.Ativo : false;
        }
    }
}
