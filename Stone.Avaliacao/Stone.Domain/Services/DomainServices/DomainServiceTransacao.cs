using System;
using System.Collections.Generic;
using System.Linq;
using Ninject;
using Stone.Domain.Contracts.Repository;
using Stone.Domain.Contracts.Services;
using Stone.Domain.Model.Entities;

namespace Stone.Domain.Services.DomainServices
{
    public class DomainServiceTransacao : DomainServiceBase<Transacao, int>, IDomainServiceTransacao
    {
        private readonly IRepositoryTransacao _repositorio;

        public DomainServiceTransacao(IRepositoryTransacao repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public IList<Transacao> ObterTransacoesPorPeriodo(DateTime inicioPeriodo, DateTime terminoPeriodo)
        {
            return _repositorio.FindAll().Where(x => x.Data >= inicioPeriodo && x.Data <= terminoPeriodo).ToList();
        }
    }
}
