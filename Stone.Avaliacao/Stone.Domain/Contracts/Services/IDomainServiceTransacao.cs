using System;
using System.Collections.Generic;
using Stone.Domain.Model.Entities;

namespace Stone.Domain.Contracts.Services
{
    public interface IDomainServiceTransacao : IDomainServiceBase<Transacao, int>
    {
        IList<Transacao> ObterTransacoesPorPeriodo(DateTime inicioPeriodo, DateTime terminoPeriodo);
    }
}